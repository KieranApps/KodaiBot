using System;
using AutoMapper;
using Discord;
using KodaiBot.RepositoryLayer.Interfaces;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.BusinessLayer
{
    public class CommandBase 
    {
        internal Logger Logger;
        internal IUnitOfWork UnitOfWork;
        internal IMapper Mapper;

        public CommandBase(Logger logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Execute()
        {
            if (!CanExecute())
            {
                Logger.Log($"Command {this.GetType().Name } does not meet the requirements to be Executed", this.GetType().Name, LogSeverity.Warning);
                return;
            }

            UnitOfWork.BeginTransaction();
            Logger.Log($"Command { this.GetType().Name } is ready to be Executed", this.GetType().Name);
            try
            {
                OnExecute();
                UnitOfWork.Commit();
                Logger.Log($"Command { this.GetType().Name } has succesfully been executed", this.GetType().Name);
            }
            catch (Exception exception)
            {
                UnitOfWork.RollBack();
                Logger.Log(exception.Message, this.GetType().Name, LogSeverity.Critical, exception);
            }
        }

        internal virtual bool CanExecute()
        {
            return true;
        }

        internal virtual void OnExecute()
        {

        }

        internal bool CheckPrerequisite(bool prerequisite, string refusalMessage = "")
        {
            if (prerequisite)
            {
                Logger.Log($"Prerequisite condition from { this.GetType().Name } command has succesfully been met", this.GetType().Name);
            }
            else
            {
                Logger.Log(refusalMessage, this.GetType().Name, LogSeverity.Warning);
            }

            return prerequisite;
        }

    }
}

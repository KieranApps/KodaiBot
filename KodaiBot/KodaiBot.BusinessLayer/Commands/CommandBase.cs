﻿using System;
using AutoMapper;
using Discord;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
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
            try
            {
                UnitOfWork.BeginTransaction();
                CanExecute();

                Logger.Log($"Command { this.GetType().Name } is ready to be Executed", this.GetType().Name);

                OnExecute();
                UnitOfWork.Commit();
                Logger.Log($"Command { this.GetType().Name } has succesfully been executed", this.GetType().Name);
            }
            catch (Exception exception)
            {
                Logger.Log(exception.Message, this.GetType().Name, LogSeverity.Critical, exception);
                UnitOfWork.RollBack();
                throw;
            }
        }

        internal virtual void CanExecute()
        {
        }

        internal virtual void OnExecute()
        {
        }

        internal void CheckPrerequisite(bool prerequisite, string refusalMessage = "")
        {
            if (prerequisite)
            {
                Logger.Log($"Prerequisite condition from { this.GetType().Name } command has succesfully been met", this.GetType().Name);
            }
            else
            {
                throw new Exception(refusalMessage);
            }
        }

    }
}

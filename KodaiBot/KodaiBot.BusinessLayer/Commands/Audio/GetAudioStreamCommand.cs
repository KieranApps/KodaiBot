using System;
using System.Diagnostics;
using System.IO;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class GetAudioStreamCommand : CommandBase
    {
        public Stream Result { get; private set; }

        public GetAudioStreamCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override void OnExecute()
        {
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = "-i ./ -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            var process = Process.Start(ffmpeg);

            if (process == null) throw new Exception("Stream couldn't be established");

            Result = process.StandardOutput.BaseStream;
        }
    }
}

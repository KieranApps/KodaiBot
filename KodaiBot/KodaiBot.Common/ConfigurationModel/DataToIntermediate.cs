using AutoMapper;
using DATA = KodaiBot.Common.DataModel;
using IM = KodaiBot.Common.IntermediateModel;

namespace KodaiBot.Common.ConfigurationModel
{
    public class DataToIntermediate : Profile
    {
        public DataToIntermediate()
        {
            CreateMap<DATA.Alias, IM.Alias>();
            CreateMap<DATA.Guild, IM.Guild>()
                .ForMember(src => src.Name, opt => opt.Ignore())
                .ForMember(src => src.Aliases, opt => opt.Ignore())
                .ForMember(src => src.Users, opt => opt.Ignore());
            CreateMap<DATA.User, IM.User>()
                .ForMember(src => src.Name, opt => opt.Ignore())
                .ForMember(src => src.Aliases, opt => opt.Ignore())
                .ForMember(src => src.Guids, opt => opt.Ignore());
            CreateMap<DATA.Snapshot, IM.Snapshot>();
        }
    }
}

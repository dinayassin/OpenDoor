using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenDoorAPI.Contracts;
using AutoMapper;

namespace OpenDoorAPI
{
    public static class Mapping
    {
        public static bool IsNotNull(byte[] In)
        {
            if (In != null)
                return true;
            return false;
        }
        public static void Map()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Role, RoleDTO>();
                    cfg.CreateMap<RoleDTO, Role>();


                    cfg.CreateMap<UserProfile, UserProfileDTO>();
                    cfg.CreateMap<UserProfileDTO, UserProfile>();
                    using (var db = new EFOpenDoor_Context())
                    {
                        cfg.CreateMap<UserCredntialsDTO, UserCredntials>()
                        .ForMember(dest => dest.Role, opt => opt.MapFrom(src => db.Role.FirstOrDefault(r => r.RoleID == src.RoleID)));
                    }
                    cfg.CreateMap<UserCredntials, UserCredntialsDTO>()
                    .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.Role.RoleID));



                    cfg.CreateMap<Visitor, VisitorDTO>();
                    cfg.CreateMap<VisitorDTO, Visitor>();


                    cfg.CreateMap<Log, LogDTO>();
                    cfg.CreateMap<LogDTO, Log>();


                    cfg.CreateMap<Log, ResultLogDTO>()
                    .ForMember(dest => dest.LogPicIsExist, opt => opt.MapFrom(src =>( src.Picture == "" || src.Picture == null)
                                               ? false
                                               : true))
                    .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.UserProfile.Fname + " " + src.UserProfile.Lname));

                });
        }
    }
}
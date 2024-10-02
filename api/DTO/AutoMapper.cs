using api.Dto;
using api.Models;
using AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>();
        CreateMap<Dorm, LargeDormDto>();
        CreateMap<Dorm, SmallDormDto>();
    }
}
using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles; 

public class PlatformsProfile : Profile {
  protected PlatformsProfile() {
    CreateMap<Platform, PlatformReadDto>();
    CreateMap<PlatformCreateDto, Platform>();
  }
}
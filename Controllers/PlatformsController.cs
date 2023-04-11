using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers; 

[Route("api/platforms")]
[ApiController]
public class PlatformsController : ControllerBase {
  private readonly IPlatformRepo platformRepo;
  private readonly IMapper mapper;

  public PlatformsController(IPlatformRepo platformRepo, IMapper mapper) {
    this.platformRepo = platformRepo;
    this.mapper = mapper;
  }
  
  [HttpGet]
  public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() {
    var platforms = platformRepo.GetAllPlatforms();
    return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
  }
  
  [HttpGet("{id}", Name = "GetPlatformById")]
  public ActionResult<PlatformReadDto> GetPlatformById(int id) {
    var platform = platformRepo.GetPlatformById(id);

    if (platform == null) {
      return NotFound();
    }
    
    return Ok(mapper.Map<PlatformReadDto>(platform));
  }
}
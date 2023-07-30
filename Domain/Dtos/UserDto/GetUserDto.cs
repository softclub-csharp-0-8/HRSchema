using Domain.Dtos.AuthenticationAuthorizationDto;

namespace Domain.Dtos.UserDto;

public class GetUserDto:UserBaseDto
{
    public List<RoleDto> Roles { get; set; } 
}


    
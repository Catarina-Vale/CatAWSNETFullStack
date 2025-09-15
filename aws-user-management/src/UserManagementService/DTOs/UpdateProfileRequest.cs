

namespace UserManagementService.DTOs
{
    public class UpdateProfileRequest
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string UserId { get; set; }
}
}
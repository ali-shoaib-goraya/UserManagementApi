namespace UserManagementApi.Interfaces
{
    public class ISoftDeletable
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}

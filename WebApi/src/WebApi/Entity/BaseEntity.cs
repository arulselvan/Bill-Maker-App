namespace WebApi.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity: IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }       
    }
}

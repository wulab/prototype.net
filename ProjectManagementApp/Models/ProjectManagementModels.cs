using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectManagementApp.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User { }

    public class UserMetaData
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage="Not a valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project { }

    public class ProjectMetaData
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 100000000)]
        public decimal Budget { get; set; }
    }

    [MetadataType(typeof(TaskMetaData))]
    public partial class Task { }

    public class TaskMetaData
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Cost { get; set; }

        [Required]
        [DisplayName("Task Type")]
        public int TaskTypeId { get; set; }

        [Required]
        [DisplayName("Task Status")]
        public int TaskStatusId { get; set; }
    }
}
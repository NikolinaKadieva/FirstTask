namespace FirstTask.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }


        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }


        [Required]
        [MaxLength(20)]
        public string City { get; set; }


        [Required]
        [MaxLength(20)]
        public string Education { get; set; }
    }
}

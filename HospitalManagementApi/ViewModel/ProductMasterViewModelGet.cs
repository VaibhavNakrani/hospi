using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.ViewModel
{
    public class ProductMasterViewModelGet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30), MinLength(3)]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        [FromForm]
        public string ProductImage { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal? Weight { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }
        public bool IsActive { get; set; }
    }
}

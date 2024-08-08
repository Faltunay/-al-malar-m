using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad alanı en az 2, en fazla 50 karakter olmalıdır.")]
        public string? Name { get; set; }

        private string? _phone;
        
        [Required(ErrorMessage = "Telefon numarası alanı zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefon numarası 11 rakamdan oluşmalıdır.")]
        public string? Phone 
        { 
            get => _phone;
            set => _phone = RemoveSpaces(value); // Boşlukları kaldıran özel method
        }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string? Email { get; set; }

        public bool WillAttend { get; set; }

        private string? RemoveSpaces(string? input)
        {
            return input?.Replace(" ", "");
        }
    }
}

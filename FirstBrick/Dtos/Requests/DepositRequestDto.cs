﻿using System.ComponentModel.DataAnnotations;

namespace FirstBrick.Dtos.Requests;

public class DepositRequestDto
{
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "The amount must be a positive number.")]
    public double Amount { get; set; }

}

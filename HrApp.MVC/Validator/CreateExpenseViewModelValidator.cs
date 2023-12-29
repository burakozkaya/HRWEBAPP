﻿using FluentValidation;
using HrApp.MVC.Models;
using HrApp.MVC.Models.Expense;

namespace HrApp.MVC.Validator
{
    public class CreateExpenseViewModelValidator : AbstractValidator<CreateExpenseViewModel>
    {

        public CreateExpenseViewModelValidator() 
        {
            
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required").LessThan(100000).WithMessage("Amount must be less then 100000.").GreaterThanOrEqualTo(1).WithMessage("Amount must be greater then 0.");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency type is required");
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage("Expense type is required");
            RuleFor(x => x.File).NotEmpty().WithMessage("File is required");

        }
    }
}

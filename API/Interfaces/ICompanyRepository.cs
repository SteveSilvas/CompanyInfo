﻿using CompanyInfo.DTOs;
using CompanyInfo.Models;

namespace CompanyInfo.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<List<Empresa>> GetAllAsync();

        public Task<int> Create(Empresa company);

        public Empresa? GetByCNPJ(string cnpj);
    }
}

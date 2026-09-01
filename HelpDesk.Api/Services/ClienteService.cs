using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Api.Data;
using HelpDesk.Api.DTOs;
using HelpDesk.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Api.Services
{
    public class ClienteService : IClienteService
    {
        private AppDbContext _appDbContext;

        public ClienteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AddClienteDTO> AddClienteAsync(AddClienteDTO addClienteDTO)
        {
            var cpfExists = await _appDbContext.Cliente.AnyAsync(c => c.Cpf == addClienteDTO.Cpf);
            if (cpfExists)
            {
                throw new Exception("O CPF informado já está em uso.");
            }

            var emailExists = await _appDbContext.Cliente.AnyAsync(c => c.Email == addClienteDTO.Email);
            if (emailExists)
            {
                throw new Exception("O e-mail informado já está em uso.");
            }

            var cliente = new Cliente(
                addClienteDTO.Nome,
                addClienteDTO.Email,
                addClienteDTO.Cpf,
                addClienteDTO.Telefone,
                addClienteDTO.Empresa,
                DateTime.Now
                );

            _appDbContext.Cliente.Add(cliente);
            await _appDbContext.SaveChangesAsync();
            return addClienteDTO;
        }

        public async Task<ClienteResponseDTO> GetClienteByIdAsync(long id)
        {
            var cliente = await _appDbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                Telefone = cliente.Telefone,
                Empresa = cliente.Empresa
            };
        }

        public async Task<List<ClienteResponseDTO>> GetAllClientesAsync()
        {
            List<ClienteResponseDTO> clientes = await _appDbContext.Cliente
                .Select(cliente => new ClienteResponseDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    Telefone = cliente.Telefone,
                    Empresa = cliente.Empresa
                })
                .ToListAsync();
            return clientes;
        }

        public async Task<ClienteResponseDTO> GetClienteByCpfAsync(string cpf)
        {
            var cliente = await _appDbContext.Cliente.FirstOrDefaultAsync(c => c.Cpf == cpf);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                Telefone = cliente.Telefone,
                Empresa = cliente.Empresa
            };
        }

        public async Task<ClienteResponseDTO> GetClienteByEmailAsync(string email)
        {
            var cliente = await _appDbContext.Cliente.FirstOrDefaultAsync(c => c.Email == email);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                Telefone = cliente.Telefone,
                Empresa = cliente.Empresa
            };
        }

        public async Task<List<ClienteResponseDTO>> GetClientesByNomeAsync(string nome)
        {
            string termo = $"%{nome}%";

            var clientes = await _appDbContext.Cliente.Where(c => EF.Functions.ILike(c.Nome, termo)).ToListAsync();

            return clientes.Select(c => new ClienteResponseDTO
            {
                Nome = c.Nome,
                Email = c.Email,
                Cpf = c.Cpf,
                Telefone = c.Telefone,
                Empresa = c.Empresa
            }).ToList();
        }
    }
}

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
    /// <summary>
    /// Implementação do serviço de cliente, responsável por gerenciar operações relacionadas a clientes no sistema de Help Desk.
    /// </summary>
    public class ClienteService : IClienteService
    {
        private AppDbContext _appDbContext;

        /// <summary>
        /// Inicializa uma nova instância do serviço de cliente com o contexto do banco de dados.
        /// </summary>
        /// <param name="appDbContext">O contexto do banco de dados.</param>
        public ClienteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Adiciona um novo cliente ao sistema de Help Desk.
        /// </summary>
        /// <param name="addClienteDTO">O DTO contendo os dados do cliente a ser adicionado.</param>
        /// <returns>O DTO com os dados do cliente adicionado.</returns>
        /// <exception cref="Exception">Lançada quando o CPF ou e-mail já estiverem em uso.</exception>
        /// <example>await clienteService.AddClienteAsync(new AddClienteDTO { Nome = "João da Silva", Email = "joao.silva@example.com", Cpf = "123.456.789-00", Telefone = "(11) 99999-9999", Empresa = "Acme Inc." });</example>
        public async Task<AddClienteDTO> AddClienteAsync(AddClienteDTO addClienteDTO)
        {
            /*
            var cpfExists = await _appDbContext.Cliente.AnyAsync(c => c.Cpf == addClienteDTO.Cpf);
            if (cpfExists)
            {
                throw new Exception("O CPF informado já está em uso.");
            }
            */

            var emailExists = await _appDbContext.Cliente.AnyAsync(c => c.Email == addClienteDTO.Email);
            if (emailExists)
            {
                throw new Exception("O e-mail informado já está em uso.");
            }

            var cliente = new Cliente(
                addClienteDTO.Nome,
                addClienteDTO.Email,
                //addClienteDTO.Cpf,
                addClienteDTO.Telefone,
                (long)addClienteDTO.IdEmpresa,
                DateTime.UtcNow
                );

            _appDbContext.Cliente.Add(cliente);
            await _appDbContext.SaveChangesAsync();
            return addClienteDTO;
        }

        /// <summary>
        /// Obtém um cliente pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do cliente.</param>
        /// <returns>O DTO com os dados do cliente encontrado.</returns>
        /// <example>var cliente = await clienteService.GetClienteByIdAsync(1);</example>
        public async Task<ClienteResponseDTO> GetClienteByIdAsync(long id)
        {
            var cliente = await _appDbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteResponseDTO
            {
                Id = cliente.IdCliente,
                Nome = cliente.Nome,
                Email = cliente.Email,
                //Cpf = cliente.Cpf,
                Telefone = cliente.Telefone,
                Empresa = cliente.Empresa
            };
        }

        /// <summary>
        /// Obtém todos os clientes cadastrados no sistema de Help Desk.
        /// </summary>
        /// <returns>A lista de DTOs com os dados dos clientes encontrados.</returns>
        /// <example>var clientes = await clienteService.GetAllClientesAsync();</example>
        public async Task<List<ClienteResponseDTO>> GetAllClientesAsync()
        {
            List<ClienteResponseDTO> clientes = await _appDbContext.Cliente
                .Select(cliente => new ClienteResponseDTO
                {
                    Id = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    //Cpf = cliente.Cpf,
                    Telefone = cliente.Telefone,
                    Empresa = cliente.Empresa
                })
                .ToListAsync();
            return clientes;
        }

        /*
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
        */

        /// <summary>
        /// Obtém um cliente pelo seu e-mail.
        /// </summary>
        /// <param name="email">O e-mail do cliente.</param>
        /// <returns>O DTO com os dados do cliente encontrado.</returns>
        /// <example>var cliente = await clienteService.GetClienteByEmailAsync("joao.silva@example.com");</example>
        public async Task<ClienteResponseDTO> GetClienteByEmailAsync(string email)
        {
            var cliente = await _appDbContext.Cliente.FirstOrDefaultAsync(c => c.Email == email);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteResponseDTO
            {
                Id = cliente.IdCliente,
                Nome = cliente.Nome,
                Email = cliente.Email,
                //Cpf = cliente.Cpf,
                Telefone = cliente.Telefone,
                Empresa = cliente.Empresa
            };
        }

        /// <summary>
        /// Obtém clientes pelo seu nome.
        /// </summary>
        /// <param name="nome">O nome do cliente.</param>
        /// <returns>A lista de DTOs com os dados dos clientes encontrados.</returns>
        /// <example>var clientes = await clienteService.GetClientesByNomeAsync("joA");</example>
        public async Task<List<ClienteResponseDTO>> GetClientesByNomeAsync(string nome)
        {
            string termo = $"%{nome}%";

            var clientes = await _appDbContext.Cliente.Where(c => EF.Functions.ILike(c.Nome, termo)).ToListAsync();

            return clientes.Select(c => new ClienteResponseDTO
            {
                Nome = c.Nome,
                Email = c.Email,
                //Cpf = c.Cpf,
                Telefone = c.Telefone,
                Empresa = c.Empresa
            }).ToList();
        }
    }
}

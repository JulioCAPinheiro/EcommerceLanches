﻿using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        /*
            
          Criasse uma pasta chamada Context e dentro dela se cria a classe de seu app com "nome(DbContext)" importando o DbContext de Entity Framework

          O DbContext Tem funcionalidade como 
          
            - Conexão com o DataBase
            - Operações com Dados
            - Consulta e persistência
            - Mapeamento de dados
            - Gestão de transações

         */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /*
           
          Dentro do DbSet<T> se feito as tabelas onde sé tem

            - Coleção para entidade de modelo
            - Coleções na memória
            - Para persistir usar SaveChanges();

          Para usar exemplo: public DbSet<Modelo> "nomeDoModelo"  { get; set; }

         */

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}

USE [LojaNet]
GO
/****** Object:  StoredProcedure [dbo].[ProdutoAlterar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoAlterar]
(
	@Id varchar(50),
	@Nome varchar(100),
	@Preco decimal(20, 2),
	@Quantidade int
) as
update Produtos set
	Id = @Id,
	Nome = @Nome,
	Preco = @Preco,
	Quantidade = @Quantidade;
GO
/****** Object:  StoredProcedure [dbo].[ProdutoCriar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoCriar]
(
	@Id varchar(50),
	@Nome varchar(100),
	@Preco decimal(20, 2),
	@Quantidade int
) as
insert into Produtos (Id, Nome, Preco, Quantidade)
values (@Id, @Nome, @Preco, @Quantidade);
GO
/****** Object:  StoredProcedure [dbo].[ProdutoDeletar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoDeletar]
(
	@Id varchar(50)
) as
delete from Produtos 
	where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[ProdutoObterPorId]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoObterPorId]
(
	@Id varchar(50)
) as
select Id, Nome, Preco, Quantidade from Produtos
where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[ProdutoObterTodos]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoObterTodos]
as
select Id, Nome, Preco, Quantidade from Produtos;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioAlterar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsuarioAlterar]
(
	@Id varchar(50),
	@Nome varchar(100),
	@Email varchar(100),
	@Telefone varchar(100),
	@Senha varchar(100),
	@Role int
)
as
update Usuarios set
	Id = @Id,
	Nome = @Nome,
	Email = @Email,
	Telefone = @Telefone,
	Senha = @Senha,
	Role = @Role
	where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioCriar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioCriar](
	@Id varchar(50),
	@Nome varchar(100),
	@Email varchar(100),
	@Telefone varchar(100),
	@Senha varchar(100),
	@Role int
) as
insert into Usuarios (Id, Nome, Email, Telefone, Senha, Role)
values (@Id, @Nome, @Email, @Telefone, @Senha, @Role);
GO
/****** Object:  StoredProcedure [dbo].[UsuarioDeletar]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioDeletar](
	@Id varchar(50)
) as
delete from Usuarios where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioObterPorId]    Script Date: 11/03/2023 17:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioObterPorId](
	@Id varchar(50)
) as
select Id, Nome, Email, Telefone, Senha, Role from  Usuarios
where Id = @Id;
GO

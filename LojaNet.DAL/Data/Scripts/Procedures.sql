USE [LojaNet]
GO
/****** Object:  StoredProcedure [dbo].[PedidoAlterar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PedidoAlterar]
(
	@Id varchar(50),
	@UsuarioId varchar(50)
) as
update Pedidos set Id = @Id, UsuarioId = @UsuarioId
where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[PedidoCriar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoCriar]
(
	@Id varchar(50),
	@UsuarioId varchar(50)
) as
insert into Pedidos (Id, UsuarioId)
values (@Id, @UsuarioId);
GO
/****** Object:  StoredProcedure [dbo].[PedidoDeletar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoDeletar]
(
	@Id varchar(50)
) as
delete from Pedidos where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[PedidoItemAlterar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoItemAlterar]
(
	@Id varchar(50),
	@Preco decimal(20, 2),
	@ProdutoId varchar(50),
	@PedidoId varchar(50)
) as
update PedidoItems set Id = @Id, Preco = @Preco, ProdutoId = @ProdutoId, PedidoId = @PedidoId;
GO
/****** Object:  StoredProcedure [dbo].[PedidoItemCriar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoItemCriar]
(
	@Id varchar(50),
	@Preco decimal(20, 2),
	@ProdutoId varchar(50),
	@PedidoId varchar(50)
) as
insert into PedidoItems (Id, Preco, ProdutoId, PedidoId)
values (@Id, @Preco, @ProdutoId, @PedidoId);
GO
/****** Object:  StoredProcedure [dbo].[PedidoItemObterPorId]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoItemObterPorId]
(
	@Id varchar(50)
) as
select Id, Preco, ProdutoId, PedidoId from PedidoItems 
where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[PedidoItemObterPorPedido]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoItemObterPorPedido]
(
	@PedidoId varchar(50)
) as
select Id, Preco, ProdutoId, PedidoId from PedidoItems 
where PedidoId = @PedidoId;
GO
/****** Object:  StoredProcedure [dbo].[PedidoObterPorid]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoObterPorid]
(
	@Id varchar(50)
) as
select Id, UsuarioId from Pedidos
where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[PedidoObterTodos]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PedidoObterTodos]
(
	@UsuarioId varchar(50)
) as
select Id, UsuarioId from Pedidos
where UsuarioId = @UsuarioId;
GO
/****** Object:  StoredProcedure [dbo].[ProdutoAlterar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ProdutoAlterar]
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
	Quantidade = @Quantidade
	where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[ProdutoCriar]    Script Date: 11/03/2023 20:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[ProdutoDeletar]    Script Date: 11/03/2023 20:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[ProdutoObterPorId]    Script Date: 11/03/2023 20:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[ProdutoObterTodos]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProdutoObterTodos]
as
select Id, Nome, Preco, Quantidade from Produtos;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioAlterar]    Script Date: 11/03/2023 20:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioCriar]    Script Date: 11/03/2023 20:01:04 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioDeletar]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioDeletar](
	@Id varchar(50)
) as
delete from Usuarios where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioObterPorEmail]    Script Date: 11/03/2023 20:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioObterPorEmail]
(
	@Email varchar(100)
) as 
select Id, Email, Nome, Telefone, Senha, [Role] from Usuarios where Email = @Email;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioObterPorId]    Script Date: 11/03/2023 20:01:04 ******/
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

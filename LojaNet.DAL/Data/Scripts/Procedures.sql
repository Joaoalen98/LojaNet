USE [LojaNet]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioAlterar]    Script Date: 11/03/2023 17:11:40 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioCriar]    Script Date: 11/03/2023 17:11:40 ******/
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
/****** Object:  StoredProcedure [dbo].[UsuarioDeletar]    Script Date: 11/03/2023 17:11:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UsuarioDeletar](
	@Id varchar(50)
) as
delete from Usuarios where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioObterPorId]    Script Date: 11/03/2023 17:11:40 ******/
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

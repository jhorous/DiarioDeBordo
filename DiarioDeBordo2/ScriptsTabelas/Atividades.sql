﻿CREATE TABLE [dbo].[Table]
(
	[CODATIVIDADE] INT NOT NULL PRIMARY KEY, 
    [CODATIVIDADEPRINCIPAL] NCHAR(10) NULL, 
    [IDTTIPOATIVIDADE] NCHAR(1) NOT NULL, 
    [DESCRICAOATIVIDADE] NCHAR(50) NOT NULL
)
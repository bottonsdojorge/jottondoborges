-- CLIENTE
INSERT INTO Cliente(Nome, CPF, Email) 
	VALUES ('José Antonio Pinto',
		'16831111416',
		'jose.antonio@gmail.com')
GO
INSERT INTO Cliente(Nome, CPF, Email) 
	VALUES ('Maria Sarah',
		'33510056280',
		'maria.sarah@gmail.com')
GO
INSERT INTO Cliente(Nome, CPF, Email) 
	VALUES ('Antonio Carlos',
		'16794297604',
		'antonio.carlos@gmail.com')
GO
INSERT INTO Cliente(Nome, CPF, Email) 
	VALUES ('Nestor Cai Cantano',
		'56716624279',
		'nestor.caicantano@gmail.com')
GO

-- FUNCIONARIO
INSERT INTO Funcionario(Nome, Motorista, Tecnico, Identidade, CLT, Salario)
	VALUES ('Jorje Sola Drão',
			0,
			1,
			'393796577',
			'12045442740',
			100.0
		)
GO
INSERT INTO Funcionario(Nome, Motorista, Tecnico, Identidade, CLT, Salario)
	VALUES ('Pedro Omos Trão',
			0,
			1,
			'460568401',
			'12092013060',
			10000.0
		)
GO
INSERT INTO Funcionario(Nome, Motorista, Tecnico, Identidade, CLT, Salario)
	VALUES ('Nestor Ofi Não',
			1,
			0,
			'188873521',
			'12056033552',
			100.0
		)
GO
INSERT INTO Funcionario(Nome, Motorista, Tecnico, Identidade, CLT, Salario)
	VALUES ('Leon Ocum Nista',
			1,
			0,
			'505932994',
			'12023122840',
			10000.0
		)
GO

-- ENDERECOS FUNCIONARIO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Funcionario_id)
	VALUES ('RN',
		'Natal',
		'Zona Norte',
		'Rua Fundi Quintal',
		'155',
		1
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Funcionario_id)
	VALUES ('RN',
		'Natal',
		'Pitimbu',
		'Rua Trembolândia',
		'5000',
		2
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Funcionario_id)
	VALUES ('RN',
		'Natal',
		'Tirol',
		'Rua Finolândia',
		'1246',
		3
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Funcionario_id)
	VALUES ('RN',
		'Natal',
		'Tirol',
		'Rua Passandofomelândia',
		'1831',
		4
	)
GO

-- ENDERECOS CLIENTES
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Cliente_id)
	VALUES ('RN',
		'Natal',
		'Zona Norte',
		'Rua Rodrigo Matos',
		'9162',
		1
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Cliente_id)
	VALUES ('RN',
		'Natal',
		'Pitimbu',
		'Rua Aluisio Neto',
		'1742',
		2
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Cliente_id)
	VALUES ('RN',
		'Natal',
		'Tirol',
		'Rua Dr Rey Presidente',
		'1826',
		3
	)
GO
INSERT INTO Endereco(Estado, Cidade, Bairro, Rua, Numero, Cliente_id)
	VALUES ('RN',
		'Natal',
		'Tirol',
		'Rua Bolsominion',
		'1641',
		4
	)
GO

-- TEL FUNCIONARIOS
INSERT INTO Telefone(Telefone, Funcionario_id)
	VALUES ('998561824',
		1
	)
GO
INSERT INTO Telefone(Telefone, Funcionario_id)
	VALUES ('998561745',
		2
	)
GO
INSERT INTO Telefone(Telefone, Funcionario_id)
	VALUES ('987981824',
		3
	)
GO
INSERT INTO Telefone(Telefone, Funcionario_id)
	VALUES ('985741824',
		4
	)
GO
-- TEL CLIENTE
INSERT INTO Telefone(Telefone, Cliente_id)
	VALUES ('998561934',
		1
	)
GO
INSERT INTO Telefone(Telefone, Cliente_id)
	VALUES ('998563765',
		2
	)
GO
INSERT INTO Telefone(Telefone, Cliente_id)
	VALUES ('987989572',
		3
	)
GO
INSERT INTO Telefone(Telefone, Cliente_id)
	VALUES ('985743698',
		4
	)
GO
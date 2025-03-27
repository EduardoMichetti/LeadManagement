CREATE TABLE TB_LEAD (
	Id BIGINT PRIMARY KEY IDENTITY(1,1), -- Identificador único da entidade, auto incremento
    Active BIT NOT NULL, -- Indica se a entidade está ativa
    CreatedDate DATETIME2 NOT NULL, -- Data de criação da entidade
    ContactFirstName NVARCHAR(50) NOT NULL, -- Primeiro nome do contato
    ContactFullName NVARCHAR(255) NOT NULL, -- Nome completo do contato
    ContactPhoneNumber NVARCHAR(50) NOT NULL, -- Número de telefone do contato
    ContactEmail NVARCHAR(255) NOT NULL, -- Email do contato
    Suburb NVARCHAR(255) NOT NULL, -- Subúrbio onde o contato reside
    Category NVARCHAR(255) NOT NULL, -- Categoria do lead
    Description NVARCHAR(MAX) NOT NULL, -- Descrição do lead
    Price FLOAT NOT NULL, -- Preço associado ao lead
	PriceAccepted FLOAT NOT NULL, -- Preço associado ao lead aceito
    Status INT NOT NULL -- Status do lead (0: Pending, 1: Approved, 2: Rejected, 3: Done)
);

-- Adicionando comentários às colunas
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único da entidade', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Id;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Indica se a entidade está ativa', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Active;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Data de criação da entidade', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = CreatedDate;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Primeiro nome do contato', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = ContactFirstName;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nome completo do contato', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = ContactFullName;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Número de telefone do contato', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = ContactPhoneNumber;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Email do contato', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = ContactEmail;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Subúrbio onde o contato reside', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Suburb;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Categoria do lead', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Category;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Descrição do lead', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Description;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Preço associado ao lead', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Price;
	
	EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Preço associado ao lead aceito', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = PriceAccepted;

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Status do lead (0: Pending, 1: Approved, 2: Rejected, 3: Done)', 
    @level0type = N'SCHEMA', @level0name = dbo, 
    @level1type = N'TABLE',  @level1name = TB_LEAD, 
    @level2type = N'COLUMN', @level2name = Status;

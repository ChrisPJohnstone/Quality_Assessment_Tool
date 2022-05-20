--Ref Program Version
BEGIN
	CREATE TABLE [Table].[Ref_Program_Version] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Program_Version] INT IDENTITY(1,1) NOT NULL
		, [Active] BIT NOT NULL
		, [Location] VARCHAR(max) NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Program_Version] PRIMARY KEY CLUSTERED ([Program_Version] DESC)
	)
END;

--Ref Permission
BEGIN
	CREATE TABLE [Table].[Ref_Permission] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Permission] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Program] BIT NOT NULL
		, [Agent] BIT NOT NULL
		, [Assessor] BIT NOT NULL
		, [Admin] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Permission] PRIMARY KEY CLUSTERED ([Permission] ASC)
	)
END;

--Ref Team
BEGIN
	CREATE TABLE [Table].[Ref_Team] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Team] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Team] PRIMARY KEY CLUSTERED ([Team] DESC)
		, CONSTRAINT [Unique_Ref_Team] UNIQUE NONCLUSTERED ([Name] ASC)
	)
END;

--Ref User
BEGIN
	CREATE TABLE [Table].[Ref_User] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [User] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [System_Name] VARCHAR(100) NULL
		, [Team] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Team] ([Team])
		, [Permission] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Permission] ([Permission])
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_User] PRIMARY KEY CLUSTERED ([User] DESC)
		, CONSTRAINT [Unique_Ref_User] UNIQUE NONCLUSTERED ([Name] ASC)
	)
END;

--CSR Comments
BEGIN
	CREATE TABLE [Table].[CSR_Comments] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Comment_For] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_User] ([User])
		, [Comment_By] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_User] ([User])
		, [Comment_Date] DATE NOT NULL
		, [Comment] INT IDENTITY(1,1) NOT NULL
		, [Notes] VARCHAR(max) NOT NULL
		, CONSTRAINT [PK_CSR_Comments] PRIMARY KEY CLUSTERED ([Comment] DESC)
		, CONSTRAINT [Unique_CSR_Comments] UNIQUE NONCLUSTERED ([Comment_Date] DESC, [Comment_For] ASC)
	)
END;

--Ref Assessment Area
BEGIN
	CREATE TABLE [Table].[Ref_Assessment_Area] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Assessment_Area] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Assessment_Area] PRIMARY KEY CLUSTERED ([Assessment_Area] DESC)
		, CONSTRAINT [Unique_Ref_Assessment_Area] UNIQUE NONCLUSTERED ([Name] ASC)
	)
END;

--Ref Question Set
BEGIN
	CREATE TABLE [Table].[Ref_Question_Set] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Assessment_Area] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Assessment_Area] ([Assessment_Area])
		, [Question_Set] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Question_Set] PRIMARY KEY CLUSTERED ([Question_Set] DESC)
	)
END;

--Ref Assessment Type
BEGIN
	CREATE TABLE [Table].[Ref_Assessment_Type] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Question_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question_Set] ([Question_Set])
		, [Assessment_Type] INT IDENTITY(1,1) NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Assessment_Type] PRIMARY KEY CLUSTERED ([Assessment_Type] DESC)
		, CONSTRAINT [Unique_Ref_Assessment_Type] UNIQUE NONCLUSTERED ([Question_Set] ASC, [Name] ASC)
	)
END;

--Ref Distribution Channel
BEGIN
	CREATE TABLE [Table].[Ref_Distribution_Channel] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Question_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question_Set] ([Question_Set])
		, [Distribution_Channel] INT IDENTITY(1,1) NOT NULL
		, [Distribution_Channel_Order] INT NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Distribution_Channel] PRIMARY KEY CLUSTERED ([Distribution_Channel] DESC)
		, CONSTRAINT [Unique_Ref_Distribution_Channel] UNIQUE NONCLUSTERED ([Question_Set] DESC, [Name] ASC)
	)
END;

--Ref Interaction Type
BEGIN
	CREATE TABLE [Table].[Ref_Interaction_Type] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Question_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question_Set] ([Question_Set])
		, [Interaction_Type] INT IDENTITY(1,1) NOT NULL
		, [Interaction_Type_Order] INT NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Active] BIT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Interaction_Type] PRIMARY KEY CLUSTERED ([Interaction_Type] DESC)
		, CONSTRAINT [Unique_Ref_Interaction_Type] UNIQUE NONCLUSTERED ([Question_Set] DESC, [Name] ASC)
	)
END;

--Ref Answer Weight
BEGIN
	CREATE TABLE [Table].[Ref_Answer_Weight] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Answer_Weight] INT IDENTITY(1,1) NOT NULL
		, [Score_Value] INT NOT NULL
		, [Max_Score_Value] INT NOT NULL
		, [Fail_Limit] INT NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Answer_Weight] PRIMARY KEY CLUSTERED ([Answer_Weight] DESC)
	)
END;

--Ref Answer Set
BEGIN
	CREATE TABLE [Table].[Ref_Answer_Set] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Answer_Set] INT IDENTITY(1,1) NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Answer_Set] PRIMARY KEY CLUSTERED ([Answer_Set] DESC)
	)
END;

--Ref Answer
BEGIN
	CREATE TABLE [Table].[Ref_Answer] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Answer_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Answer_Set] ([Answer_Set])
		, [Answer] INT IDENTITY(1,1) NOT NULL
		, [Answer_Order] INT NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Answer_Weight] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Answer_Weight] ([Answer_Weight])
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Answer] PRIMARY KEY CLUSTERED ([Answer] DESC)
		, CONSTRAINT [Unique_Ref_Answer] UNIQUE NONCLUSTERED ([Answer_Set] ASC, [Answer_Order] ASC)
	)
END;

--Ref Tab
BEGIN
	CREATE TABLE [Table].[Ref_Tab] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Question_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question_Set] ([Question_Set])
		, [Tab] INT IDENTITY(1,1) NOT NULL
		, [Tab_Order] INT NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Tab] PRIMARY KEY CLUSTERED ([Tab] DESC)
		, CONSTRAINT [Unique_Ref_Tab] UNIQUE NONCLUSTERED ([Question_Set] DESC, [Tab_Order] ASC)
	)
END;

--Ref Question
BEGIN
	CREATE TABLE [Table].[Ref_Question] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Tab] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Tab] ([Tab])
		, [Question] INT IDENTITY(1,1) NOT NULL
		, [Question_Order] INT NOT NULL
		, [Name] VARCHAR(100) NOT NULL
		, [Description] VARCHAR(max) NOT NULL
		, [Answer_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Answer_Set] ([Answer_Set])
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Ref_Question] PRIMARY KEY CLUSTERED ([Question] DESC)
		, CONSTRAINT [Unique_Ref_Question] UNIQUE NONCLUSTERED ([Tab] DESC, [Question_Order] ASC)
	)
END;

--Assessment
BEGIN
	CREATE TABLE [Table].[Assessment] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Assessment] INT IDENTITY(1,1) NOT NULL
		, [Assessment_Date] DATE NOT NULL
		, [Assessment_Time] TIME(0) NOT NULL
		, [Assessment_By] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_User] ([User])
		, [Assessment_Area] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Assessment_Area] ([Assessment_Area])
		, [Question_Set] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question_Set] ([Question_Set])
		, [Assessment_Type] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Assessment_Type] ([Assessment_Type])
		, [Interaction_Date] DATE NOT NULL
		, [Interaction_Time] TIME(0) NOT NULL
		, [Interaction_By] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_User] ([User])
		, [Interaction_Reference] VARCHAR(100) NOT NULL
		, [Distribution_Channel] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Distribution_Channel] ([Distribution_Channel])
		, [Interaction_Type] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Interaction_Type] ([Interaction_Type])
		, [Outcome] VARCHAR(100) NOT NULL
		, [Signed_Off] BIT NOT NULL
		, [Signed_Off_By] INT NULL FOREIGN KEY REFERENCES [Table].[Ref_User] ([User])
		, [Signed_Off_Date] DATE NULL
		, [Signed_Off_Time] TIME(0) NULL
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED ([Assessment] DESC)
		, CONSTRAINT [Unique_Assessment] UNIQUE NONCLUSTERED ([Interaction_Reference] ASC)
	)
END;

--Assessment Detail
BEGIN
	CREATE TABLE [Table].[Assessment_Detail] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Assessment] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Assessment] ([Assessment])
		, [Question] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Question] ([Question])
		, [Answer] INT NOT NULL FOREIGN KEY REFERENCES [Table].[Ref_Answer] ([Answer])
		, [Notes] VARCHAR(max) NULL
		, CONSTRAINT [Unique_Assessment_Detail] UNIQUE NONCLUSTERED ([Assessment] ASC, [Question] ASC, [Answer] ASC)
	)
END;

--Access Log
BEGIN
	CREATE TABLE [Table].[Access_Log] (
		[Import_Date] DATE NOT NULL
		, [Import_Time] TIME(0) NOT NULL
		, [Added_By] VARCHAR(100) NOT NULL
		, [Access_Number] INT IDENTITY(1,1) NOT NULL
		, [Accessor] VARCHAR(500) NOT NULL
		, [Accessor_Username] VARCHAR(500) NULL
		, [Program_Version] INT NOT NULL
		, CONSTRAINT [PK_Access_Log] PRIMARY KEY CLUSTERED ([Access_Number] DESC)
	)
END;

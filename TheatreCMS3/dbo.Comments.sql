CREATE TABLE [dbo].[Comments] (
    [CommentID]   INT            IDENTITY (1, 1) NOT NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CommentDate] DATETIME       NOT NULL,
    [Likes]       INT            NOT NULL,
    [Dislikes]    INT            NOT NULL,
    [Author_Id]   NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_dbo.Comments_dbo.AspNetUsers_Author_Id] FOREIGN KEY ([Author_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Author_Id]
    ON [dbo].[Comments]([Author_Id] ASC);


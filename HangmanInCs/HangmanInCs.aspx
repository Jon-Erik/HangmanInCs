<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HangmanInCs.aspx.cs" Inherits="HangmanInCs.HangmanInCs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <link href="HangmanInCsStyles.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Libre+Franklin" rel="stylesheet"/>
</head>
<body class="container">
    <h1 class="text-center">Hangman in C#</h1>
    <div class="row">
        <div class="col-sm-4 d-flex justify-content-center">
           <img class="noose-photo" src="images/noose.jpg" alt="noose photo" />
        </div>
        <div class="col-sm-8">
            <div class="row d-flex justify-content-center">
                <p class="textlabel">Sample text</p>
            </div>
            <div class="row d-flex justify-content-center">
                <p class="textlabel">Sample text</p>
            </div>
        </div>
    </div>
</body>
</html>

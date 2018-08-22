<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HangmanInCs.aspx.cs" Inherits="HangmanInCs.HangmanInCs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <link href="HangmanInCsStyles.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Libre+Baskerville|Libre+Franklin" rel="stylesheet"/>
    <style type="text/css">
        .messagelabel {
            font-family: 'Libre Franklin', sans-serif;
            font-size: 20px;
        }

        .gameplaylabel {
            font-family: 'Libre Baskerville', serif;
            font-size: 20px;
        }
    </style>
</head>
<body class="container">
    <form id="hangmanform" runat="server">
        <div>
            <h1 class="text-center">Hangman in C#</h1>
                <div class="row">
                    <div class="col-sm-4 d-flex justify-content-center">
                       <img class="noose-photo" src="images/noose.jpg" alt="noose photo" />
                    </div>
                <div class="col-sm-8">
                    <div class="row d-flex justify-content-center">
                        <div class="messagelabeldiv">
                            <asp:Label ID="messagelabel" runat="server" CssClass="messagelabel"></asp:Label>
                        </div>
                    </div>
                    <div class="row d-flex justify-content-center">
                        <div class="gameplaylabeldiv">
                            <asp:Label ID="gameplaylabel" runat="server" CssClass="gameplaylabel"></asp:Label>                        
                        </div>
                    </div>
                    <div class="row d-flex justify-content-center">
                        <asp:Button ID="A" runat="server" OnClick="Button_Click" Text="A" class="letter-button"/>
                        <asp:Button ID="B" runat="server" OnClick="Button_Click" Text="B" class="letter-button"/>
                        <asp:Button ID="C" runat="server" OnClick="Button_Click" Text="C" class="letter-button"/>
                        <asp:Button ID="D" runat="server" OnClick="Button_Click" Text="D" class="letter-button"/>
                        <asp:Button ID="E" runat="server" OnClick="Button_Click" Text="E" class="letter-button"/>
                        <asp:Button ID="F" runat="server" OnClick="Button_Click" Text="F" class="letter-button"/>
                        <asp:Button ID="G" runat="server" OnClick="Button_Click" Text="G" class="letter-button"/>
                        <asp:Button ID="H" runat="server" OnClick="Button_Click" Text="H" class="letter-button"/>
                        <asp:Button ID="I" runat="server" OnClick="Button_Click" Text="I" class="letter-button"/>
                        <asp:Button ID="J" runat="server" OnClick="Button_Click" Text="J" class="letter-button"/>
                        <asp:Button ID="K" runat="server" OnClick="Button_Click" Text="K" class="letter-button"/>
                        <asp:Button ID="L" runat="server" OnClick="Button_Click" Text="L" class="letter-button"/>
                        <asp:Button ID="M" runat="server" OnClick="Button_Click" Text="M" class="letter-button"/>
                        <asp:Button ID="N" runat="server" OnClick="Button_Click" Text="N" class="letter-button"/>
                        <asp:Button ID="O" runat="server" OnClick="Button_Click" Text="O" class="letter-button"/>
                        <asp:Button ID="P" runat="server" OnClick="Button_Click" Text="P" class="letter-button"/>
                        <asp:Button ID="Q" runat="server" OnClick="Button_Click" Text="Q" class="letter-button"/>
                        <asp:Button ID="R" runat="server" OnClick="Button_Click" Text="R" class="letter-button"/>
                        <asp:Button ID="S" runat="server" OnClick="Button_Click" Text="S" class="letter-button"/>
                        <asp:Button ID="T" runat="server" OnClick="Button_Click" Text="T" class="letter-button"/>
                        <asp:Button ID="U" runat="server" OnClick="Button_Click" Text="U" class="letter-button"/>
                        <asp:Button ID="V" runat="server" OnClick="Button_Click" Text="V" class="letter-button"/>
                        <asp:Button ID="W" runat="server" OnClick="Button_Click" Text="W" class="letter-button"/>
                        <asp:Button ID="X" runat="server" OnClick="Button_Click" Text="X" class="letter-button"/>
                        <asp:Button ID="Y" runat="server" OnClick="Button_Click" Text="Y" class="letter-button"/>
                        <asp:Button ID="Z" runat="server" OnClick="Button_Click" Text="Z" class="letter-button"/>
                    </div>
                </div>                                     
            </div>
            <div class="justify-content-center">
                <asp:Button ID="StartResetButton" runat="server" Text="Start or Reset Word" OnClick="StartResetButton_Click" autopostback="false"/>
                <br />
                <br />
                <asp:Button ID="testbutton" runat="server" OnClick="testbutton_Click" Text="TestButton" />
                <br />
                <br />
                <asp:Label ID="TestLabel" runat="server" Text="TestLabel"></asp:Label>
            </div>
        </div>
    </form>   
</body>
</html>

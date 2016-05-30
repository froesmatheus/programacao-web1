﻿<%@ Page MasterPageFile="~/MasterPage.Master" Language="C#" AutoEventWireup="true" CodeBehind="CadastrarCliente.aspx.cs" Inherits="Exercicio12_03_16.CadastrarCliente" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <style>
            form {
                display: table;
                border-spacing: 10px;
            }

            p {
                display: table-row;
            }

            label {
                display: table-cell;
            }

            input {
                display: table-cell;
            }
        </style>
    </head>
    <body>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <ajaxToolkit:ModalPopupExtender 
            ID="ModalPopupExtender1" 
            PopupControlID="ModalPanel"
            CancelControlID="btnFechar"
            TargetControlID="labelModal"
            DropShadow="true"
            runat="server" />

        <asp:Label ID="labelModal" runat="server"/>

        <asp:Panel ID="ModalPanel" runat="server" BackColor="#0033cc" Style="padding: 16px;">
            <asp:Label ForeColor="#ffffff" Font-Bold="true" Font-Size="Medium" ID="LabelMessage" runat="server" />
            <br />
            <br />
            <asp:Button CausesValidation="false" ID="btnFechar" runat="server" Text="OK" />
        </asp:Panel>


        <div>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Exercicio12_03_16.Cliente" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetClientes" TypeName="Exercicio12_03_16.Database.ClienteDAO" UpdateMethod="Update" OnInserted="ObjectDataSource1_Inserted"></asp:ObjectDataSource>

            <asp:Panel GroupingText="Meus Dados" runat="server" Width="800px">
                <asp:FormView ID="FormView2" DataKeyNames="Id" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource1" Style="margin-top: 0px" Width="789px">
                    <EditItemTemplate>
                        <div class="container">
                            <p>
                                <label>Nome: </label>
                                <asp:TextBox ID="tbxNome" Text='<%# Bind("Nome") %>' runat="server" Width="250px" MaxLength="255" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNome"
                                    ErrorMessage="Campo obrigatório (Nome)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                            <p>
                                <label>Data de aniversário: </label>
                                <asp:TextBox ID="tbxDataNasc" Text='<%# Bind("DataNasc", "{0:d}") %>' runat="server" Width="250px" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataNasc"
                                    ErrorMessage="Campo obrigatório (Data de aniversário)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None"
                                    ErrorMessage="Data de aniversário inválida" Type="Date" ControlToValidate="tbxDataNasc"
                                    Operator="GreaterThan" ValueToCompare="01/01/1900">Data de aniversário inválida</asp:CompareValidator>
                            </p>

                            <p>
                                <label>Email: </label>
                                <asp:TextBox ID="tbxEmail" Text='<%# Bind("Email") %>' runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxEmail"
                                    ErrorMessage="Campo obrigatório (Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbxConfirmEmail"
                                    ControlToValidate="tbxEmail" ErrorMessage="Os emails não são iguais" Display="None"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxEmail"
                                    ErrorMessage="O email não é válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                            </p>

                            <p>
                                <label>Confirmação Email: </label>
                                <asp:TextBox ID="tbxConfirmEmail" runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxConfirmEmail"
                                    ErrorMessage="Campo obrigatório (Confirmação Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                            <p>
                                <label>Senha: </label>
                                <asp:TextBox ID="tbxSenha" runat="server" Text='<%# Bind("Senha") %>' TextMode="Password" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxSenha"
                                    ErrorMessage="Campo obrigatório (Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="tbxConfirmSenha"
                                    ControlToValidate="tbxSenha" Display="None" ErrorMessage="As senhas não são iguais"></asp:CompareValidator>
                            </p>

                            <p>
                                <label>Confirmação Senha: </label>
                                <asp:TextBox ID="tbxConfirmSenha" runat="server" TextMode="Password" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxConfirmSenha"
                                    ErrorMessage="Campo obrigatório (Confirmação Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                        </div>
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </EditItemTemplate>




                    <EmptyDataTemplate>
                        Nenhum cliente<br />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="New" Text="Adicionar" />
                        <br />
                    </EmptyDataTemplate>




                    <InsertItemTemplate>
                        <div class="container">
                            <p>
                                <label>Nome: </label>
                                <asp:TextBox ID="tbxNome" Text='<%# Bind("Nome") %>' runat="server" Width="250px" MaxLength="255" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNome"
                                    ErrorMessage="Campo obrigatório (Nome)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                            <p>
                                <label>Data de aniversário: </label>
                                <asp:TextBox ID="tbxDataNasc" Text='<%# Bind("DataNasc", "{0:d}") %>' runat="server" Width="250px" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDataNasc"
                                    ErrorMessage="Campo obrigatório (Data de aniversário)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None"
                                    ErrorMessage="Data de aniversário inválida" Type="Date" ControlToValidate="tbxDataNasc"
                                    Operator="GreaterThan" ValueToCompare="01/01/1900">Data de aniversário inválida</asp:CompareValidator>
                            </p>

                            <p>
                                <label>Email: </label>
                                <asp:TextBox ID="tbxEmail" Text='<%# Bind("Email") %>' runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxEmail"
                                    ErrorMessage="Campo obrigatório (Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="tbxConfirmEmail"
                                    ControlToValidate="tbxEmail" ErrorMessage="Os emails não são iguais" Display="None"></asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxEmail"
                                    ErrorMessage="O email não é válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                            </p>

                            <p>
                                <label>Confirmação Email: </label>
                                <asp:TextBox ID="tbxConfirmEmail" runat="server" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxConfirmEmail"
                                    ErrorMessage="Campo obrigatório (Confirmação Email)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                            <p>
                                <label>Senha: </label>
                                <asp:TextBox ID="tbxSenha" runat="server" Text='<%# Bind("Senha") %>' TextMode="Password" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxSenha"
                                    ErrorMessage="Campo obrigatório (Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="tbxConfirmSenha"
                                    ControlToValidate="tbxSenha" Display="None" ErrorMessage="As senhas não são iguais"></asp:CompareValidator>
                            </p>

                            <p>
                                <label>Confirmação Senha: </label>
                                <asp:TextBox ID="tbxConfirmSenha" runat="server" TextMode="Password" Width="250px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxConfirmSenha"
                                    ErrorMessage="Campo obrigatório (Confirmação Senha)" ForeColor="Red"> *</asp:RequiredFieldValidator>
                            </p>

                        </div>



                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Adicionar" />
                        &nbsp;&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                    </InsertItemTemplate>





                    <ItemTemplate>
                        Nome:
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Bind("Nome") %>' />
                        <br />
                        Data de Nascimento:
                        <asp:Label ID="dataNascLabel" runat="server" Text='<%# Bind("DataNasc", "{0:d}") %>' />
                        <br />
                        Email:
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Bind("Email") %>' />
                        <br />
                        Senha:
                        <asp:Label ID="senhaLabel" runat="server" Text='<%# Bind("Senha") %>' />
                        <br />
                        <br />
                        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Adicionar" />
                        &nbsp;&nbsp;<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Atualizar" />
                        &nbsp;&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Excluir" />
                        &nbsp;

                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server"
                            TargetControlID="DeleteButton"
                            ConfirmText="Você tem certeza que deseja excluir esse cliente?" />

                    </ItemTemplate>
                </asp:FormView>

                <br />
                <asp:ValidationSummary runat="server" DisplayMode="BulletList" ForeColor="Red" HeaderText="O formulário contém erros" ShowSummary="true" />

            </asp:Panel>
        </div>
    </body>
    </html>
</asp:Content>


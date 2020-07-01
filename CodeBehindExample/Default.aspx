<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodeBehindExample._Default" ValidateRequest="false" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Company </h1>
        <p>
            <asp:Button ID="btnNewCompany" runat="server" CssClass="btn btn-primary btn-lg" Text="New Company" OnClick="btnNewCompany_Click" />
        </p>
    </div>

    <div class="row">
        <asp:GridView ID="gvCompany" runat="server" DataKeyNames="companyID" OnSelectedIndexChanged="gvCompany_SelectedIndexChanged" OnPageIndexChanging="gvCompany_PageIndexChanging" OnRowDataBound="gvCompany_RowDataBound"></asp:GridView>
    </div>

    <div class="modal scale fade" id="ModalNewCompany" tabindex="-1" aria-labelledby="myModalLabel" role="dialog" aria-hidden="true">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Company</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Company Name</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-building"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Contact</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-id-badge"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Email</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Phone</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-phone"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtphone" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Fax</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-fax"></i></span>
                                        </div>
                                        <asp:TextBox ID="txtFax" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 form-control-label">
                                    <label>Address</label>
                                </div>
                                <div class="col-lg-9 col-md-9 col-sm-6">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control valid" Font-Size="12pt"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-flat btn-default" data-dismiss="modal">Cancelar</button>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-flat btn-primary" Text="Save" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-flat btn-primary" Text="Actualizar" Visible="false" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                        <!--.modal-content-->
                    </div>
                    <!--.modal-dialog-->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

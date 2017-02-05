<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KingTravels.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title>Login</title>
    <link href="/dist/plugins/bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/dist/plugins/font-awesome/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="/dist/plugins/ionicons/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="/dist/plugins/iCheck/square/_all.css" rel="stylesheet" type="text/css" />
    <link href="/dist/css/AdminLTE.min.css" type="text/css" rel="stylesheet" />

    <script src="/dist/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="/dist/plugins/bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <script src="/dist/plugins/bootstrap-dialog/bootstrap-dialog.min.js" type="text/javascript"></script>
    <script src="/dist/plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <script src="/dist/dialog.js" type="text/javascript"></script>
    
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="login-box">
            <div class="login-logo">
                <a href="javascript:;"><b>Login</b></a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Username" MaxLength="20" ValidationGroup="Login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="<span class='glyphicon glyphicon glyphicon-remove form-control-feedback' style='color:#d84a38;'></span>" ForeColor="#d84a38" ControlToValidate="txtEmail" EnableClientScript="true" ValidationGroup="Login" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" MaxLength="20" ValidationGroup="Login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="<span class='glyphicon glyphicon glyphicon-remove form-control-feedback' style='color:#d84a38;'></span>" ForeColor="#d84a38" ControlToValidate="txtPassword" EnableClientScript="true" ValidationGroup="Login" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <asp:CheckBox ID="chkRememberMe" runat="server" />
                                Remember Me
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block btn-flat" ValidationGroup="Login" OnClick="btnLogin_Click" />
                    </div>
                    <!-- /.col -->
                </div>
            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->

    </form>
    
    <script type="text/javascript">

        $(document).ready(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });

            $('input').on('ifChanged', function (event) {
                $(event.target).trigger('click');
            });

        });

       </script>
</body>
</html>

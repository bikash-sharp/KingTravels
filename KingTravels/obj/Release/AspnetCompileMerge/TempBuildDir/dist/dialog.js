﻿function ShowAlert(Mtype, yourmessage) {

    var msgType = BootstrapDialog.TYPE_PRIMARY;

    if (Mtype == 'INFO')
        msgType = BootstrapDialog.TYPE_INFO;
    else if (Mtype == 'PRIMARY')
        msgType = BootstrapDialog.TYPE_PRIMARY;
    else if (Mtype == 'SUCCESS')
        msgType = BootstrapDialog.TYPE_SUCCESS;
    else if (Mtype == 'WARNING')
        msgType = BootstrapDialog.TYPE_WARNING;
    else if (Mtype == 'DANGER')
        msgType = BootstrapDialog.TYPE_DANGER;
    else
    {
        msgType = BootstrapDialog.TYPE_PRIMARY;
    }
        

    BootstrapDialog.show({
        type: msgType,
        closable: true,
        closeByBackdrop: false,
        closeByKeyboard: true,
        title: 'INFORMATION',
        message: yourmessage,
        buttons: [{
            label: ' Close',
            icon: 'glyphicon glyphicon-ok-sign',
            action: function (dialogRef) {
                dialogRef.close();
            }
        }]
    });
    return;
}

function ShowMessageWithPageRedirect(Mtype, yourmessage, Page)
{
    var msgType = BootstrapDialog.TYPE_PRIMARY;
    if (Mtype == 'INFO')
        msgType = BootstrapDialog.TYPE_INFO;
    else if (Mtype == 'PRIMARY')
        msgType = BootstrapDialog.TYPE_PRIMARY;
    else if (Mtype == 'SUCCESS')
        msgType = BootstrapDialog.TYPE_SUCCESS;
    else if (Mtype == 'WARNING')
        msgType = BootstrapDialog.TYPE_WARNING;
    else if (Mtype == 'DANGER')
        msgType = BootstrapDialog.TYPE_DANGER;
    else
        msgType = BootstrapDialog.TYPE_DEFAULT;
    BootstrapDialog.show({
        type: msgType,
        closable: true,
        closeByBackdrop: false,
        closeByKeyboard: true,
        title: 'INFORMATION',
        message:yourmessage,
        buttons: [{
            label: 'OK',
            icon:'glyphicon glyphicon-ok-sign',
            action: function (dialogRef) {
                //dialogRef.close();
                window.location = Page;
            }
        }]
    });
    return;
}

function ConfirmMessage(control) {
    BootstrapDialog.confirm({
        title: 'WARNING',
        message: 'Are you sure, You want to delete this ? It will also delete all the associated items',
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY    
        btnCancelLabel: 'Cancel', // <-- Default value is 'Cancel',    
        btnOKLabel: 'Continue', // <-- Default value is 'OK',    
        btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used, 
        callback: function (result) {
            // result will be true if button was click, while it will be false if users close the dialog directly.    
            if (result) {
                var href = control.getAttribute("href");
                eval(href);

            }
            else {
                BootstrapDialog.closeAll();
            }
        }
    });
}

function ShowConfirmMessage(control, yourmessage) {
    //alert(yourmessage);
    BootstrapDialog.confirm({
        type: BootstrapDialog.TYPE_WARNING,
        closable: true,
        closeByBackdrop: false,
        closeByKeyboard: true,
        title: 'Warning ! Do You Want To Continue',
        message: yourmessage + '<br/>Click Yes To Continue',
        btnCancelLabel: 'No', // <-- Default value is 'Cancel',
        btnOKLabel: 'Yes', // <-- Default value is 'OK',
        btnOKClass: 'btn-warning',// <-- If you didn't specify it, dialog type will be used,
        btnOKIcon: 'glyphicon glyphicon-ok',
        btnCancelIcon: 'glyphicon glyphicon-remove',
        callback: function (result) {
            //result will be true if button was click
            if (result) {
                javascript: __doPostBack(control.name, '');
            }
            else {
                BootstrapDialog.closeAll();
            }
        }
    });
    return;
}

function LoadPage(page)
{
    BootstrapDialog.show({
        message: $('<div></div>').load(page),
        type: BootstrapDialog.TYPE_PRIMARY,
        closable: true,
        closeByBackdrop: false,
        closeByKeyboard: true,
        title: 'Forgot Password',
        buttons: [{
            label: 'Close',
            icon: 'glyphicon glyphicon-ok-sign',
            action: function (dialogRef) {
                dialogRef.close();
            }
        }]
    });
    return;
}


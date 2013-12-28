
function showLoader(show, text) {
    var loader = $('.loader');
    if (show) {

        if (!text) {
            text = "Working. Please wait...";
        }

        var loaderContent = '<img src="../content/themes/base/images/ajax-loader_sunny.gif" align="absmiddle">&nbsp;<span class="loading">' + text + '</span>';
        loader.html(loaderContent).show();
    }
    else {
        loader.hide();
    }
}

function showRecordListLoader(show, text) {
    var loader = $('.recordlist-loader');
    if (show) {

        if (!text) {
            text = "Loading records...";
        }

        var loaderContent = '<img src="../content/themes/base/images/ajax-loader_sunny.gif" align="absmiddle">&nbsp;<span class="loading">' + text + '</span>';
        loader.html(loaderContent).show();
    }
    else {
        loader.hide();
    }
}

function showActionLoader(show, text) {
    var actionLoader = $('.action-loader');
    if (show) {

        if (!text) {
            text = "Saving records...";
        }

        var loaderContent = '<img src="../content/themes/base/images/ajax-loader_sunny.gif" align="absmiddle">&nbsp;<span class="loading">' + text + '</span>';
        actionLoader.html(loaderContent).show();
    }
    else {
        actionLoader.hide();
    }
}

function showError(messsage) {
    $("#error-message").html(messsage);
    $("#error-message").dialog(
        {
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        }
    );
}

// Read a page's GET URL variables and return them as an associative array.
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
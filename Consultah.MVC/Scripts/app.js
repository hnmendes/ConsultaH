function removerCaracteresEspeciais(str) {
    let newStr = str.replace(/[^a-z0-9\s]/gi, '').replace(/[_\s]/g, '-');
    return newStr;
}

function getControllerName() {
    let str = window.location.pathname;
    str = str.split("/");
    return str[2];
}

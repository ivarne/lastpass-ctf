'using strict';
(function(){
    var button = document.getElementById("activate-admin-login");
    var form = document.getElementById("admin-password-login");
    button.addEventListener("click",(e)=>{
        form.hidden = !form.hidden;
    })
})()
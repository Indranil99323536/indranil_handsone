function ShowFormValue() {
    var _firstname = document.getElementById('txt_FirstName').value;
    var _lastname = document.getElementById('txt_LastName').value;
    var _swon = document.getElementById('txt_SWON').value;
    var _doj = document.getElementById('txt_DateofJoining').value;
    var _txt_Roll_NO = document.getElementById('txt_Roll_NO').value;
    var _txt_Personsal = document.getElementById('txt_Personsal ID').value;
    var _txt_Pasword = document.getElementById('txt_Password').value;

    alert(_firstname + '\n\n' + _lastname + '\n\n' + _swon + '\n\n' + _doj + '\n\n' + _txt_Roll_NO +'\n\n' + _txt_Personsal + '\n\n' + _txt_Pasword);
}
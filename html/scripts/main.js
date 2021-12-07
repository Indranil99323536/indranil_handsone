function ShowFormValue() {
    var _firstname = document.getElementById('txt_FirstName').value;
    var _lastname = document.getElementById('txt_LastName').value;
    var _swon = document.getElementById('txt_SWON').value;
    var _doj = document.getElementById('txt_DateofJoining').value;
    var _rollno = document.getElementById('txt_Roll_NO').value;
    var _txt_Personsal = document.getElementById('txt_Personsal ID').value;
    alert(_firstname + '\n\n' + _lastname + '\n\n' + _swon + '\n\n' +'\n\n' + _rollno + '\n\n' + _txt_Personsal);
}
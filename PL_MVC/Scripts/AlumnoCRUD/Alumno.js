$(document).ready(function () { 
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58535/api/alumno/',
        success: function (result) { //200 OK 
           // $('#SubCategorias tbody').empty();
            $.each(result.Objects, function (i, alumno) {
             /*   var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + alumno.IdSubCategoria + ')">'
                    + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + subCategoria.IdSubCategoria + "</td>"
                    + "<td class='text-center'>" + subCategoria.Nombre + "</td>"
                    + "<td class='text-center'>" + subCategoria.Descripcion + "</ td>"
                    + "<td class='text-center'>" + subCategoria.Categoria.IdCategoria + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + subCategoria.IdSubCategoria + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SubCategorias tbody").append(filas); */
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
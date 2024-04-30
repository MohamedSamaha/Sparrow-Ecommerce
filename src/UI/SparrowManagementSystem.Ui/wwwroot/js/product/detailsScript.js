function addItemToCart(Id, ItemPrice) {
    var ItemCount = document.getElementById('productItemCount').value;
    if (ItemCount === '' || ItemPrice === '') {
        swal('Please Enter Item Count!', {
            icon: "error",
            buttons: {
                confirm: {
                    className: 'btn btn-error'
                }
            },
        });
    }
    else {
        $.ajax({
            type: 'POST', url: "/Product/AddProductToCart", data: {
                Id: Id,
                ItemCount: ItemCount,
                ItemPrice: ItemPrice
            },
            success: function () {
                // Reload the page or update the UI as needed

                swal("Product Add To Cart Successfully", {
                    icon: "success",
                    buttons: {
                        confirm: {
                            className: 'btn btn-success'
                        }
                    },
                }).then(
                    function () {
                        window.location.reload();
                    });
            }, error: function (error) {
                swal('Something Went Wrong!', {
                    icon: "error",
                    buttons: {
                        confirm: {
                            className: 'btn btn-error'
                        }
                    },
                }).then(
                    function () {
                        window.location.reload();
                    });
            }
        });
    }
}
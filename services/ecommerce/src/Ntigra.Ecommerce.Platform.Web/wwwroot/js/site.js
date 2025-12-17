// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    // Add to cart
    $(document).on('click', '.add-to-cart', function () {
        var productId = $(this).data('id');
 
        $.post('/Cart/Add', { productId })
            .done(function (data) {
                if (data.success) {
                    showConfirmModal('Product added to cart successfully.');

                    $('#confirm-modal').off('hidden.bs.modal').on('hidden.bs.modal', function () {
                        var badge = $('.topbar-badge');
                        badge.text(data.count).show();
                    });

                }
            })
            .fail(function (xhr) {
                if (xhr.responseJSON) {
                    showErrorModal(
                        xhr.responseJSON.errorMessage,
                        xhr.responseJSON.errorCode
                    );
                } else {
                    showErrorModal('Unexpected error occurred.');
                }
            });
    });
     

    $(document).on('click', '.remove-from-cart', function () {
        var productId = $(this).data('id');

        $.post('/Cart/Remove', { productId })
            .done(function (data) {
                if (data.success) {
                    showConfirmModal('Product removed from cart successfully.');

                    $('#confirm-modal').off('hidden.bs.modal').on('hidden.bs.modal', function () {
                        location.reload();
                    });
                }
            })
            .fail(function (xhr) {

                if (xhr.responseJSON) {
                    showErrorModal(
                        xhr.responseJSON.errorMessage,
                        xhr.responseJSON.errorCode
                    );
                } else {
                    showErrorModal('Failed to remove product from cart.');
                }
            });
    });

    function showConfirmModal(message) {
        $('#confirm-modal-message').text(message);
        const modal = new bootstrap.Modal(document.getElementById('confirm-modal'));
        modal.show();
    }
    function showErrorModal(message, code = null) {
        $('#error-modal-message').text(message || 'Something went wrong.');

        if (code) {
            $('#error-modal-code').text(`Error Code: ${code}`).show();
        } else {
            $('#error-modal-code').hide();
        }

        const modal = new bootstrap.Modal(document.getElementById('error-modal'));
        modal.show();
    }

});  
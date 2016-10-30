(function () {
    axios.get('/dashboard/transactions')
        .then(function (response) {
            initializeVue(response.data.transactions);
        });

    function initializeVue(transactions) {
        new Vue({
            el: '#dashboardIndex',
            data: {
                transactions: transactions,
                showModal: false
            }
        });
    }
}());
(function () {
    axios.get('/dashboard/transactions')
        .then(function(response) {
            var dashboardTransactionsView = new Vue({
                el: '#dashboardTransactions',
                data: {
                    transactions: response.data.transactions
                }
            });
        });
}());
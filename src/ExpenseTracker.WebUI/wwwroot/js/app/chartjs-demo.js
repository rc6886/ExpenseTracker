$(function () {
    var pieChartCategoryData = [];

    axios.get('/dashboard/piechartcategories')
        .then(function(response) {
            var pieChartCategories = response.data.pieChartCategories;

            var doughnutData = {
                labels: pieChartCategories.map(x => x.categoryName),
                datasets: [
                    {
                        data: pieChartCategories.map(x => x.percentageOfExpenses),
                        backgroundColor: pieChartCategories.map(x => x.color)
                    }
                ]
            };

            var doughnutOptions = {
                responsive: true
            };

            var ctx4 = document.getElementById("doughnutChart").getContext("2d");
            new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });
        });
});
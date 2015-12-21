cuckooApp.controller('endpointsCtrl', function ($scope, JobsFactory, $location) {
    JobsFactory.getAllJobs().then(function (response) {
        $scope.endPoints = response;
    });

    $scope.showEndPointDetail = function (job) {
        JobsFactory.currentJob = job;
        $location.path('/endpoints/' + job.Id);
    }


});

cuckooApp.controller('endpointsAddCtrl', function ($scope, JobsFactory, $location, $routeParams) {


});



cuckooApp.controller('endpointsDetailCtrl', function ($scope, JobsFactory, $location, $routeParams, HttpMethodsFactory) {

    if (!JobsFactory.currentJob) {
        JobsFactory.getJobById($routeParams.id).then(function (data) {
           
            JobsFactory.currentJob = data;
            $scope.endpoint = JobsFactory.currentJob;
        });
    }
    else
    {
        $scope.endpoint = JobsFactory.currentJob;
    }

    $scope.mytime = new Date();

    $scope.hstep = 1;
    $scope.mstep = 1;

    $scope.ismeridian = true;
    $scope.toggleMode = function () {
        $scope.ismeridian = !$scope.ismeridian;
    };

    $scope.update = function () {
        var d = new Date();
        d.setHours(14);
        d.setMinutes(0);
        $scope.mytime = d;
    };

    $scope.changed = function () {
        console.log('Time changed to: ' + $scope.mytime);
    };

    $scope.clear = function () {
        $scope.mytime = null;
    };


    





    HttpMethodsFactory.getHTTPmethods().then(function (data) {

        $scope.httpMethods = data;
    });
});




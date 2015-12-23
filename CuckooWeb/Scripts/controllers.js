cuckooApp.controller('endpointsCtrl', function ($scope, JobsFactory, $location) {
    JobsFactory.getAllJobs().then(function (response) {
        $scope.endPoints = response;
    });

    $scope.showEndPointDetail = function (job) {
        JobsFactory.currentJob = job;
        $location.path('/endpoints/' + job.Id);
    }
});


cuckooApp.controller('endpointsFormCtrl', function ($scope, JobsFactory, $location, $routeParams, HttpMethodsFactory) {

    if (!$scope.endpoint)
    {
        $scope.endpoint = {};
    }

    $scope.ismeridian = true;
    $scope.toggleMode = function () {
        $scope.ismeridian = !$scope.ismeridian;
    };

    HttpMethodsFactory.getHTTPmethods().then(function (data) {
        $scope.httpMethods = data;
    });

    var constructHeadersObject = function () {
        var shell = {
            Key: '',
            Value: ''
        }
        return shell;
    }

    $scope.addNewHeader = function () {

        if (!$scope.endpoint.APIRequestHeaders) {
            $scope.endpoint.APIRequestHeaders = new Array();
        }
        $scope.endpoint.APIRequestHeaders.push(constructHeadersObject());
    };

    $scope.testEndpoint = function () {
        console.log($scope.$parent.endpoint);
        JobsFactory.testEndpoint($scope.$parent.endpoint).then(function (result) {
            $scope.$parent.testResponseMessage = result;
        });
    }

});


cuckooApp.controller('endpointsAddCtrl', function ($scope, JobsFactory, $location, $routeParams) {

    $scope.endpoint = {};

    $scope.handleEndpointSubmission = function () {
        console.log($scope);
    }
});

cuckooApp.controller('endpointsDetailCtrl', function ($scope, JobsFactory, $location, $routeParams, HttpMethodsFactory) {

    $scope.handleEndpointSubmission = function () {
        console.log("Saving");
        console.log($scope);
    }

    if (!JobsFactory.currentJob) {
        JobsFactory.getJobById($routeParams.id).then(function (data) {
            JobsFactory.currentJob = data;
            $scope.$parent.endpoint = JobsFactory.currentJob;
        });
    }
    else {
        $scope.$parent.endpoint = JobsFactory.currentJob;
    }

    $scope.$watchGroup(['httpMethods'], function(n, o)
    {
        if ($scope.httpMethods)
        {
            
        }
    });

    //$scope.ismeridian = true;
    //$scope.toggleMode = function () {
    //    $scope.ismeridian = !$scope.ismeridian;
    //};

    //HttpMethodsFactory.getHTTPmethods().then(function (data) {
    //    $scope.httpMethods = data;
    //});

    //var constructHeadersObject = function () {
    //    var shell = {
    //        Key: '',
    //        Value:''
    //    }
    //    return shell;
    //}

    //$scope.addNewHeader = function () {

    //    if (!$scope.endpoint.APIRequestHeaders)
    //    {
    //        $scope.endpoint.APIRequestHeaders = new Array();
    //    }
    //    $scope.endpoint.APIRequestHeaders.push(constructHeadersObject());
    //};

    //$scope.testEndpoint = function()
    //{
    //    JobsFactory.testEndpoint($scope.endpoint).then(function (result)
    //    {
    //        $scope.testResponseMessage = result;
    //    });
    //}

});




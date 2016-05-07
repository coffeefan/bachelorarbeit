'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('DashboardCtrl', function ($scope, $rootScope,$location,ProjectService,$routeParams,
                                           ProjectStatsLastMonthService,ProjectStatsAuthenticationService, ProjectStatsValidationTimeService
                                               ) {





        $scope.dashboard={};
        $rootScope.pageTitle = "Dashboard";
        $scope.projects=[];



        $scope.loadProjects= function(){
            ProjectService.findAll({}, $scope.project, function (data) {
                $scope.projects=data;
                if($scope.projects.length>0){
                    $scope.dashboard.selectedProject=$scope.projects[0];
                    $scope.reloadStats();
                }
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };



        $scope.loadProjectStatsLastMonth= function(){
            ProjectStatsLastMonthService.find({id:$scope.dashboard.selectedProject.ProjectId}, {}, function (data) {
                $scope.statsLastMonth=data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadProjectStatsAuthentication= function(){
            ProjectStatsAuthenticationService.find({id:$scope.dashboard.selectedProject.ProjectId}, {}, function (data) {
                $scope.authentication=data;

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadProjectStatsValidationTime= function(){
            ProjectStatsValidationTimeService.find({id:$scope.dashboard.selectedProject.ProjectId}, {}, function (data) {
                $scope.validationTime=data;

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.open=function(){
            if($scope.projects.length>0){
                $location.path("projects/detail/"+$scope.dashboard.selectedProject.ProjectId);
            }
        };

        $scope.reloadStats=function(){
            $scope.loadProjectStatsLastMonth();
            $scope.loadProjectStatsAuthentication();
            $scope.loadProjectStatsValidationTime();
        };

        $scope.loadProjects();
    });
'use strict';

/**
 * @ngdoc overview
 * @name configuratorApp
 * @description
 * # configuratorApp
 *
 * Main module of the application.
 */
angular
    .module('configuratorApp', [
        'ngAnimate',
        'ngCookies',
        'ngResource',
        'ngRoute',
        'ngSanitize',
        'ngTouch',
        'angular-loading-bar',
        'ngStorage'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/main.html',
                controller: 'MainCtrl',
                controllerAs: 'main'
            })
            .when('/about', {
                templateUrl: 'views/about.html',
                controller: 'AboutCtrl',
                controllerAs: 'about'
            })
            .when('/change-password', {
                templateUrl: 'views/changePassword.html',
                controller: 'ChangePasswordCtrl',
                controllerAs: 'changepassword'
            })
            .when('/confirm-registration', {
                templateUrl: 'views/confirmRegistration.html',
                controller: 'ConfirmRegistrationCtrl',
                controllerAs: 'confirmregistration'
            })
            .when('/forgot-password', {
                templateUrl: 'views/forgotPassword.html',
                controller: 'ForgotPasswordCtrl',
                controllerAs: 'forgotPassword'
            })
            .when('/forgot-password-confirm', {
                templateUrl: 'views/forgotPasswordConfirm.html',
                controller: 'ForgotPasswordConfirmCtrl',
                controllerAs: 'forgotPasswordConfirm'
            })
            .when('/login', {
                templateUrl: 'views/login.html',
                controller: 'LoginCtrl',
                controllerAs: 'login'
            })
            .when('/logout', {
                templateUrl: 'views/logout.html',
                controller: 'LogoutCtrl',
                controllerAs: 'logout'
            })
            .when('/registration', {
                templateUrl: 'views/registration.html',
                controller: 'RegistrationCtrl',
                controllerAs: 'registration'
            })
            .otherwise({
                redirectTo: '/'
            });
    }).run(function ($rootScope, $window, $sessionStorage, $location) {
        $rootScope.ServiceUrl = "http://localhost:55636/";

        $rootScope.isLoggedIn = false;
        if (typeof $sessionStorage.accessToken != 'undefined') {
            $rootScope.isLoggedIn = true;
        }

        $rootScope.genders = [
            {key: 'men', name: 'Männlich'},
            {key: 'women', name: 'Weiblich'}
        ];
});

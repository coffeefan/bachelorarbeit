'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:ForgotPasswordService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */

angular.module('configuratorApp').
factory('ForgotPasswordService', function($resource,$rootScope){
    return $resource($rootScope.ServiceUrl+'api/Account/ForgotPassword', {}, {
        'forgot': { method:'POST' }
    });
});
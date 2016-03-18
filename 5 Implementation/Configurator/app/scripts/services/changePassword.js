'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:ChangePasswordService
 * @description
 * # ChangePasswordService
 * Service of the configuratorApp
 */

'use strict';

angular.module('configuratorApp').
factory('ChangePasswordService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Account/ResetPassword', {}, {
        'reset': { method:'POST'}
    });
});
import api from './api';

//Axios Interceptors manipulate the header, body, parameters of the requests
// sent to the server so that we don’t need to add headers in Axios requests like this:
// axios.get(API_URL, { headers: authHeader() })
// So we remove auth-header.js file, then update services that use it with new api service.
// Further reading: https://www.bezkoder.com/vue-3-refresh-token/

class UserService {
  getPublicContent() {
    return api.get('/test/all');
  }

  getUserBoard() {
    return api.get('/test/user');
  }

  getModeratorBoard() {
    return api.get('/test/mod');
  }

  getAdminBoard() {
    return api.get('/test/admin');
  }
}

export default new UserService();

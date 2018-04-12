<template>
  <div>
    <nav class="navbar">
      <!-- <div class="flexor"> -->
        <router-link :to="{name: 'Home'}" class="rtr-lnk">
            
          <div class="container">
            <div class="row d-flex justify-content-end">
              <div class="col-md-3"> 
              <img class="pad-r" src="../assets/fish.png" height="100px">
            </div>
            <div class="col-md-9">
           
                <h1><Center>Keep-R</Center></h1>         
              </div>
            </div>
          </div>
        </router-link>
      <!-- </div> -->
      <div v-if="!user._id">
        <div class="dropdown pointer">
          <a class="dropdown-toggle" role="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <span>
              <i class="fas fa-sign-in-alt"></i>
            </span>
          </a>
          <div class="dropdown-menu" aria-labelledby="dropdownMenu1">
            <div class="dropdown-item pointer ddcss" data-toggle="modal" data-target="#register">
              Register
            </div>
            <div class="dropdown-item pointer ddcss" data-toggle="modal" data-target="#login">
              Log In
            </div>

          </div>
          </div>
        </div>
        <div v-else>
          <div class="dropdown pointer">
            <a class="dropdown-toggle" role="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              <span>{{user.username}}
                <i class="fas fa-user"></i>
              </span>
            </a>
            <div class="dropdown-menu" aria-labelledby="dropdownMenu1">
              <router-link to="/manage-vaults">
              <div class="dropdown-item pointer">
                Manage Vaults
              </div>
              </router-link>
              <button @click.prevent="logout" class="dropdown-item pointer ddcss" type="button">Log Out</button>
            </div>
          </div>
        </div>
      </nav>
      <!-- Register user start -->
      <div class="modal fade" id="register" tabindex="-1" role="dialog">
          <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content full-width">
              <img class="mid" src="../assets/fish.png" height="125" width="125">
              <form @submit.prevent="createUser(createdUser)">
                <div class="modal-body">
                  <div class="m-2">
                    <i class="fas mar-right fa-1x fa-user"></i>
                    <input type="text" name="username" v-model="createdUser.username" placeholder=" Username" required>
                  </div>
                  <div class="m-2">
                    <i class="far mar-right fa-1x fa-envelope"></i>
                    <input type="email" name="useremail" v-model="createdUser.email" placeholder="Email" required>
                  </div>
                  <div class="m-2">
                    <i class="far mar-right fa-1x fa-edit"></i>
                    <input type="password" name="password" v-model="createdUser.password" placeholder=" Password">
                  </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-sm grey-btn" data-dismiss="modal">
                    <b>Cancel</b>
                  </button>
                  <button type="submit" class="btn btn-sm blue-btn">
                    <b>User Registration</b>
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
        <!-- Login User Start -->
            <!-- Login Modal Start -->
        <div class="modal fade" id="login" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-dialog-centered" role="document">
              <div class="modal-content full-width">
                <img class="mid" src="../assets/fish.png" height="125" width="125">
                <form @submit.prevent="login(user)">
              <div class="modal-body">
                <div class="m-2">
                  <i class="far mar-right fa-1x fa-envelope"></i>
                  <input type="text" name="userEmail" v-model="user.email" placeholder=" Email" required>
                </div>
                <div class="m-2">
                  <i class="far mar-right fa-1x fa-edit"></i>
                  <input type="password" name="password" v-model="user.password" placeholder=" Password">
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-sm dkblue-btn" data-dismiss="modal">
                  <b>close</b>
                </button>
                <button type="submit" class="btn btn-sm blue-btn">
                  <b>Login</b>
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
  </div>
  
  
</template>

<script>
    import Home from "./Home"
    export default {
        name: 'Dashboard',
        data() {
            return {
                createdUser: {}
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            logout() {
                this.$store.dispatch('logout')
            },
            login() {
                this.$store.dispatch('login', this.user)
                $('#login').modal('hide')
            },
            createUser(createdUser) {
                this.$store.dispatch('createUser', this.createdUser)
                $('#register').modal('hide')
                this.createdUser = {}
            },
            manageVaults() {
                this.$store.dispatch('getVaults', this.user)
                $('#vaults').modal('hide')
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    /* :dashboard {
        background-color: black;
        height: 200px;
        color: white;
    } */
    
    .ddcss {
        color: rgb(60, 81, 121);
        background-color: rgb(214, 221, 255);
        font-style: normal;
    }
    
    .navbar {
        /* position: absolute; */
        background-color: rgb(60, 81, 121);
        color: white;
        height: 16vh;
        width: 100%;
        z-index: 500;
    }
    
    .blue-btn {
        background-color: #3b5c8b;
        color: white;
        transition: all .3s linear;
    }
    
    .blue-btn:hover {
        background-color: #6ea4f0;
        color: white;
    }
    
    .dkblue-btn {
        background-color: #38437c;
        color: white;
        transition: all .3s linear;
    }
    
    .dkblue-btn hover {
        background-color: #8f9fff;
        color: white;
    }
    
    .mid {
        margin: .5rem auto;
    }
    
    input {
        width: 95%;
    }
    
    a {
        color: #fff;
    }
    
    a:hover {
        text-decoration: none
    }
    
    .pointer {
        cursor: pointer;
    }
    
    .dropdown-menu {
        min-width: 0;
        padding: 1rem 0;
        margin-right: 10px;
        left: -8rem;
        z-index: 1021;
    }
    
    .dropdown-item:hover {
        background-color: #f9f9f9;
    }
    
    .flexor {
        display: flex;
        align-items: flex-end;
        justify-content: space-around;
    }
    
    .flexor h3 {
        margin-bottom: 0;
    }
    
    .pad-r {
        padding-right: 1rem;
    }
    
    .navbar h1 {
        font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif, sans-serif;
        font-weight: 800;
        font-size: 3.5rem;
        color: yellow;
    }
    
    .rtr-lnk {
        width: 90%;
    }
</style>
<template>
  <div class="home">
     
        <dashboard class="no-scroll"></dashboard>
   
    <div class="px-bkground"></div>
    <div class="container">
         <div class="row d-inline-flex justify-content-center p-2" v-for="keep in keeps">
             <div class="col-sm-3">
                <div class="card card-layout text-white bg-info mb-3">
                    <img src="">
                    <div class="card-body">
                        <router-link :to="{name: 'Keep'}" class="rtr-lnk">
                            <h5 class="card-title">{{keep.name}}</h5>
                        </router-link>
                        <p class="card-text">{{keep.description}}</p>
                        <a href="" class="btn btn-primary">Article link</a>
                    </div>
                    
                </div> 
             </div>
        </div>
    </div>
</div>

</template>

<script>
    import Dashboard from './DashBoard'
    export default {
        name: 'Home',
        components: {
            Dashboard
        },
        props: {

        },
        data() {
            return {

            }
        },
        mounted() {
            this.$store.dispatch('getPublicKeeps');
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
                console.log(this.$store.state.keeps);
            }
        },
        methods: {

        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .px-bkground {
        background-image: url("../assets/milkyway.png");
        position: absolute;
        /* Set a specific height */
        height: 1000px;
        width: 100%;
        /* Create the parallax scrolling effect */
        background-attachment: fixed;
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
        z-index: -99;
    }
    /* .no-scroll {
        position: fixed;
        top: 0;
        left: 0;
        z-index: 999;
        width: 100%;
    } */
    
    .card-layout {
        width: 12rem;
        height: 15rem;
    }
    
    h1 {
        color: white;
    }
    
    .rtr-lnk {
        background-color: #38437c;
        color: white;
        transition: all .3s linear;
    }
    
    .rtr-lnk hover {
        background-color: #8f9fff;
        color: yellow;
    }
</style>
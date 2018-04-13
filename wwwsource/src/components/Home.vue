<template>
  <div class="home">
     
        <dashboard></dashboard>
   
    <div class="px-bkground"></div>
    <div class="container">
         <div class="row d-inline-flex justify-content-center p-2" v-for="keep in keeps">
             <div class="col-sm-3">
                <div class="card card-layout text-white bg-info mb-3">
                    <img class="thumbnail" :src= keep.imgurl >
                    <div class="card-body">
                        <router-link :to="{name: 'Keep'}" class="rtr-lnk">
                            <h5 class="card-title">{{keep.name}}</h5>
                        </router-link>
                        <p class="card-text">{{keep.description}}</p>
                        <p>Article link <a :href = keep.articleurl class="art-link">here</a></p>
                        <div class="hoverspan"><center>Hover over me!</center>
                            <div class="container hidestuff">
                                <div class="row hoverstuff justify-content-around m-2">
                                    <div class="col-xs-4">Views: {{keep.nbrviews}}</div>
                                    <div class="col-xs-4">Keeps:  {{keep.nbrkeeps}}</div>
                                </div>
                                <div class="row justify-content-between m-2">
                                    <div class="col-xs-4"><button type="button" class="btn button btnkeep"></button></div>
                                    <div class="col-xs-4"> <button type="button" class="btn button btnshare"></button></div>
                                    <div class="col-xs-4"><button type="button" class="btn button btninspect"></button></div>
                                </div>
                            </div>
                        </div>
                   
                    </div>
                </div> 
             </div>
        </div>
    </div>
</div>

</template>

<script>
    import Dashboard from './Dashboard'
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
            console.log("in Home, mounted");
            this.$store.dispatch('getPublicKeeps');
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            user() {
                return this.$store.state.user
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
    
    .btnkeep {
        background-image: url(../assets/btnkeep.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .btnshare {
        background-image: url(../assets/btnshare.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .btninspect {
        background-image: url(../assets/btninspect.png);
        background-repeat: no-repeat;
        /* background-position: 0px 0px; */
        border: none;
        cursor: pointer;
        height: 40px;
        width: 40px;
        vertical-align: bottom;
    }
    
    .card-layout {
        width: 15rem;
        height: 25rem;
    }
    
    .card-layout h5 {
        font-size: 12pt;
        text-align: center;
    }
    
    .card-layout p {
        font-size: 11pt;
        text-align: center;
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
    
    .thumbnail {
        height: 120px;
        width: 120px;
        align-self: center;
    }
    
    .art-link {
        color: yellow;
    }
    
    .hoverstuff {
        align-items: center;
    }
    
    .hidestuff {
        padding: 20px;
        visibility: hidden;
        cursor: pointer;
    }
    
    .hoverdiv {
        width: 100%;
    }
    
    .hoverspan:hover .hidestuff {
        visibility: visible;
        cursor: pointer;
        width: 100%;
    }
</style>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Core.MusicInfo;

namespace Core.Data
{
    public class SampleData : DropCreateDatabaseAlways<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { GenreName = "摇滚", Description="从20世纪50年代起，人们在广播和唱片中认识了一种新的流行音乐，这种音乐每一拍节奏都非常强烈，歌词写的也十分新鲜，一下子征服了许多美国人的心。1951年，美国克利夫兰电台首次播放这类音乐时，为了使听众感到新鲜，一位名叫艾伦·弗里德的播音员在播放前介绍时，给这种音乐命名为“摇滚乐”。1955年，一位名叫Bill Haley的歌星演唱并录制了一张名叫《整日摇滚》（Rock Around the Clock）的唱片，引起了极大的轰动，前后出售了1500多万张，成为世界上最畅销的唱片之一，摇滚音乐的名称便由此而来。"},
                new Genre { GenreName = "爵士",Description="爵士乐（Jazz），于19世纪末20世纪初源于美国，诞生于南部港口城市新奥尔良，音乐根基来自布鲁斯（Blues）和拉格泰姆（Ragtime）。爵士乐讲究即兴，以具有摇摆特点的Shuffle节奏为基础，是非洲黑人文化和欧洲白人文化的结合。20世纪前十几年爵士乐主要集中在新奥尔良发展，1917年后转向芝加哥，30年代又转移至纽约，直至今天，爵士乐风靡全球。爵士乐的主要风格有：新奥尔良爵士、摇摆乐、比博普、冷爵士、自由爵士、拉丁爵士、融合爵士等。"},
                new Genre { GenreName = "金属",Description="金属乐以重金属为主，[1]  包括黑金属，死亡金属，激流金属，新金属，厄运金属，华丽金属，重金属，工业金属等重型音乐。"},
                new Genre { GenreName = "朋克",Description="朋克（Punk），又译为庞克，诞生于七十年代中期，一种源于六十年代车库摇滚和前朋克摇滚的简单摇滚乐。它是最原始的摇滚乐——由一个简单悦耳的主旋律和三个和弦组成，经过演变，朋克已经逐渐脱离摇滚，成为一种独立的音乐，朋克音乐不太讲究音乐技巧，更加倾向于思想解放和反主流的尖锐立场，这种初衷在二十世纪七十年代特定的历史背景下在英美两国都得到了积极效仿，最终形成了朋克运动。同时，朋克音乐在年轻人中十分流行，为世界多地青年所喜爱。"},
                new Genre { GenreName = "迪斯科",Description="“Disco”这个词是“Discotheque”的简称，原意是指“供人跳舞的舞厅”，60年代初源于法国。60年代，随着音乐设备的更新，舞厅里只要拥有一套唱片播放机就可以完成原来乐队的工作，并且还可以随时得到各种不同的音乐，即经济又实惠。因此，各大舞厅不再雇佣乐队来伴奏，而是雇佣一名唱片播放员通过播放唱片来提供伴舞音乐。慢慢的，人们把这种由唱片播放出来的跳舞音乐也称作迪斯科。"},
                new Genre { GenreName = "蓝调",Description="蓝调（英文：Blues，解作“蓝色”，又音译为布鲁斯）是一种基于五声音阶的声乐和乐器音乐，它的另一个特点是其特殊的和声。蓝调起源于过去美国黑人奴隶的灵魂乐、赞美歌、劳动歌曲、叫喊和圣歌。蓝调中使用的“蓝调之音”和启应的演唱方式都显示了它的西方来源。"},
                new Genre { GenreName = "民谣",Description="民间流行的、赋予民族色彩的歌曲，称为民谣或民歌。民谣的历史悠远，故其作者多不知名。民谣的内容丰富，有宗教的、爱情的、战争的、工作的，也有饮酒、舞蹈作乐、祭典等等。民谣表现一个民族的感情与习尚，因此各有其独特的音阶与情调风格。如法国民谣的蓬勃、意大利民谣的热情、英国民谣的淳朴、日本民谣的悲愤、西班牙民谣的狂放不羁、中国民谣的缠绵悱恻，都表现了强烈的民族气质与色彩。"},
                new Genre { GenreName = "乡村音乐",Description="乡村音乐（country music）是一种具有美国民族特色的流行音乐，于20世纪20年代兴起于美国南部，其根源来自英国民谣，是美国白人民族音乐代表。乡村音乐的特点是曲调简单，节奏平稳，带有叙事性，具有较浓的乡土气息，亲切热情而不失流行元素。多为歌谣体、二部曲式或三部曲式。" },
                new Genre { GenreName = "流行",Description="流行音乐(POP Music)，是全球最受欢迎的一种音乐风格。流行音乐是根据英语Popular Music翻译过来的。按照汉语词语表面去理解，所谓流行音乐，是指那些结构短小、内容通俗、形式活泼、情感真挚，并被广大群众所喜爱，广泛传唱或欣赏，流行一时的甚至流传后世的器乐曲和歌曲。这些乐曲和歌曲，植根于大众生活的丰厚土壤之中。因此，又有\"大众音乐\"之称。" }
            };

            var artists = new List<Artist>
            {
                new Artist { ArtistName = "Adele",                  Description="阿黛尔·阿德金斯（Adele Adkins），1988年5月5日出生于伦敦托特纳姆，英国流行歌手。2008年，阿黛尔发行了首张专辑《19》，获得当年水星音乐奖提名，并在全球取得了超过900万的销售量。其中的单曲《Chasing Pavements》助其获得格莱美最佳新人和最佳流行女歌手两座大奖。2011年，阿黛尔推出第二张录音室专辑《21》，拥有三支冠军单曲。" },
                new Artist { ArtistName = "Beyond",                 Description="Beyond，中国香港摇滚乐队，由黄家驹、黄贯中、黄家强、叶世荣组成[1-3]  。1983年Beyond成立，同年参加“山叶吉他比赛”获得冠军并正式出道。1986年自资发行乐队首张专辑《再见理想》。1988年凭借粤语专辑《秘密警察》获得关注。1989年凭借歌曲《真的爱你》获得第12届十大中文金曲奖、第7届十大劲歌金曲奖[4]  。1990年凭借歌曲《光辉岁月》获得第8届十大劲歌金曲奖[2]  。1991年9月，Beyond在香港红磡体育馆举办“生命接触”演唱会[5]  。1992年，Beyond赴日本发展演艺事业。1993年发行粤语专辑《乐与怒》，专辑中的歌曲《海阔天空》获得第16届十大中文金曲奖[6]  ；6月30日，乐队主唱黄家驹去世，Beyond以三名成员的组成形式继续发展。" },
                new Artist { ArtistName = "Taylor Swift"       , Description="泰勒·斯威夫特（Taylor Swift），1989年12月13日出生于美国宾夕法尼亚州，美国流行音乐、乡村音乐创作型女歌手、音乐制作人、演员、慈善家。2006年与独立唱片公司大机器唱片签约，发行首张录音室专辑《泰勒·斯威夫特》，获美国唱片业协会认证5倍白金唱片[1]。2008年发行第二张录音室专辑《Fearless》，在美国公告牌专辑榜上获11周冠军，是2009年全美最畅销专辑，认证7倍白金唱片[2]  ，专辑获第52届格莱美奖年度专辑，使泰勒成为获此奖项的最年轻歌手， [3]  也是获奖最多的乡村音乐专辑[4]  。" },
                new Artist { ArtistName = "Michael Jackson"   , Description="迈克尔·杰克逊（Michael Jackson，1958年8月29日-2009年6月25日），出生于美国印第安纳州加里市，美国歌手、词曲创作人、舞蹈家、表演家、慈善家、音乐家、人道主义者、和平主义者、慈善机构创办人。杰克逊是家族的第七个孩子，他在1964年作为杰克逊五人组的成员和他的兄弟一起在职业音乐舞台上初次登台，1968年乐队与当地的一家唱片公司合作出版了第一张唱片《Big Boy》。1971年12月，发行了个人首支单曲《Got to be there》，标志着其个人独唱生涯的开始。" },
                new Artist { ArtistName = "阿杜"              , Description="阿杜（Ado），原名杜成义，1973年3月11日出生于新加坡，新加坡歌手。在当歌手之前，阿杜是建筑工地的工头，直到有一天，阿杜陪同朋友去参加一个三千多人报名的试音比赛，意外受到评审的肯定与青睐，立刻与他签约为培训的歌手，加入海蝶唱片，从此步入歌坛。2002年发行第一张专辑《天黑》；同年，发行专辑《坚持到底》。2007年，发行专辑《差一点》[1]  ，阿杜凭借歌曲《差一点》获得雪碧原创港台金曲奖[2]  。2008年，发行专辑《Do The Best》[3]  。2010年，发行专辑《没什么好怕》[4-5]  ，并凭借该专辑获得CCTV《环球红歌盛典》媒体推荐最具特色艺人大奖。2011年11月8日，签约乐华娱乐[6]  。2012年，发行专辑《第9次初恋》[7]  。2013年，参与安徽卫视的综艺节目《我为歌狂》[8]  。" },
                new Artist { ArtistName = "陈奕迅"             , Description="陈奕迅（Eason Chan），1974年7月27日出生于香港，中国香港男歌手、演员，毕业于英国金斯顿大学。1995年因获得第14届新秀歌唱大赛冠军而正式出道。1996年发行个人首张专辑《陈奕迅》。1997年主演个人首部电影《旺角大家姐》。1998年凭借歌曲《天下无双》在乐坛获得关注。2000年发行的歌曲《K歌之王》奠定其在歌坛的地位[1]  。2001年发行流行摇滚风格的专辑《反正是我》。2003年发行个人首张概念专辑《黑·白·灰》；专辑中的歌曲《十年》获得第4届百事音乐风云榜十大金曲奖[2]  。" },
                new Artist { ArtistName = "刀郎"              , Description="刀郎，原名罗林。1971年6月22日出生于四川省内江市资中县，歌手、音乐人。2004年以单曲《2002年的第一场雪》正式出道，2005年凭借《冲动的惩罚》获全国“金唱片”奖，2006年推出专辑《谢谢你》和《披着羊皮的狼》。2011至2012年间举办“刀郎-谢谢你全国巡回演唱会”，2011年8月10日，推出专辑《刀郎2011-身披彩衣的姑娘》，2012年以《爱是你我》获第十二届“五个一工程”奖。" },
                new Artist { ArtistName = "范玮琪"             , Description="范玮琪（Fan Fan），1976年3月18日出生于美国俄亥俄州，华语流行乐女歌手、影视演员、主持人。1999年，签约福茂唱片，成为旗下签约艺人，并进行了为期一年的培训。2000年，推出首张个人音乐专辑《范范的世界》，从而正式进军歌坛[1]  。2001年，凭借专辑《范范的世界》入围“第12届台湾金曲奖”最佳新人奖[2]  ；同年，推出第二张个人音乐专辑《太阳》[3]  。2002年，出演个人首部电视剧《爱情白皮书》[4]  。2003年，推出第三张个人音乐专辑《真善美》[5]  。2004年，在都市爱情喜剧《醋溜族》中饰演女主角小红[6]  。" },
                new Artist { ArtistName = "古巨基"             , Description="古巨基，1972年8月18日出生于香港，中国香港男歌手、演员、主持人，毕业于沙田官立中学。1991年，出演个人首部电视剧《横财三千万》，从而正式进入演艺圈。1992年，担任无线电视娱乐新闻节目《娱乐新闻眼》的主持人。1994年，推出首张个人音乐专辑《爱的解释》，从而正式进军乐坛[1]  。1997年，获”叱咤乐坛流行榜颁奖典礼“叱咤乐坛男歌手银奖。2000年，在民国情感剧《情深深雨濛濛》中饰演男主角何书桓[2]  。2003年，在古装言情剧《还珠格格第三部》中饰演五阿哥爱新觉罗·永琪[3]  。2004年，获得“叱咤乐坛流行榜颁奖典礼'叱咤乐坛男歌手金奖、叱咤乐坛我最喜爱的男歌手、叱咤乐坛我最喜爱的歌曲大奖[4]  。'" },
                new Artist { ArtistName = "海明威"             , Description="" },
                new Artist { ArtistName = "黄大炜"             , Description="" },
                new Artist { ArtistName = "金玟岐"             , Description="" },
                new Artist { ArtistName = "李玉刚"             , Description="" },
                new Artist { ArtistName = "李宗盛"             , Description="" },
                new Artist { ArtistName = "梁静茹"             , Description="" },
                new Artist { ArtistName = "林俊杰"             , Description="" },
                new Artist { ArtistName = "刘德华"             , Description="" },
                new Artist { ArtistName = "毛宁"              , Description="" },
                new Artist { ArtistName = "张学友"             , Description="" },
                new Artist { ArtistName = "莫文蔚"             , Description="" },
                new Artist { ArtistName = "朴树"              , Description="" },
                new Artist { ArtistName = "齐秦"              , Description="" },
                new Artist { ArtistName = "王杰"              , Description="" },
                new Artist { ArtistName = "王菲"              , Description="" },
                new Artist { ArtistName = "王力宏"             , Description="" },
                new Artist { ArtistName = "伍佰"              , Description="" },
                new Artist { ArtistName = "薛之谦"             , Description="" },
                new Artist { ArtistName = "杨丞琳"             , Description="" },
                new Artist { ArtistName = "张赫宣"             , Description="" },
                new Artist { ArtistName = "张惠妹"             , Description="" },
                new Artist { ArtistName = "张信哲"             , Description="" },
                new Artist { ArtistName = "赵雷"              , Description="" },
                new Artist { ArtistName = "周传雄"             , Description="" },
                new Artist { ArtistName = "周杰伦"             , Description="" },
                new Artist { ArtistName = "任贤齐"             , Description="" },
                new Artist { ArtistName = "陈东升"             , Description="" },
                new Artist { ArtistName = "光良"              , Description="" },
            };

            new List<Album>
            {
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "Adele的专辑"            , Genre = genres.Single(g => g.GenreName ==  "摇滚"      ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "Adele"              ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "Beyond的专辑"           , Genre = genres.Single(g => g.GenreName ==  "爵士"      ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "Beyond"                 ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "Taylor Swift的专辑"     , Genre = genres.Single(g => g.GenreName ==  "金属"      ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "Taylor Swift"            ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "Michael Jackson的专辑"  , Genre = genres.Single(g => g.GenreName ==  "朋克"      ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==      "Michael Jackson"        ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "阿杜的专辑"              , Genre = genres.Single(g => g.GenreName == "迪斯科"    ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "阿杜"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "陈奕迅的专辑"            , Genre = genres.Single(g => g.GenreName ==  "蓝调"      ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "陈奕迅"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "刀郎的专辑"              , Genre = genres.Single(g => g.GenreName == "民谣"       ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "刀郎"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "范玮琪的专辑"            , Genre = genres.Single(g => g.GenreName ==  "乡村音乐"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "范玮琪"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "古巨基的专辑"            , Genre = genres.Single(g => g.GenreName ==  "流行"     ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "古巨基"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "海明威的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "海明威"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "黄大炜的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "黄大炜"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "金玟岐的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "金玟岐"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "李玉刚的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "李玉刚"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "李宗盛的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "李宗盛"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "梁静茹的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "梁静茹"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "林俊杰的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"            ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "林俊杰"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "刘德华的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"    ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "刘德华"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "毛宁的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "毛宁"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "张学友的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "张学友"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "莫文蔚的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "莫文蔚"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "朴树的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "朴树"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "齐秦的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "齐秦"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "王杰的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "王杰"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "王菲的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "王菲"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "王力宏的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "王力宏"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "伍佰的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "伍佰"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "薛之谦的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "薛之谦"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "杨丞琳的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "杨丞琳"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "张赫宣的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "张赫宣"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "张惠妹的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "张惠妹"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "张信哲的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "张信哲"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "赵雷的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "赵雷"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "周传雄的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "周传雄"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "周杰伦的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "周杰伦"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "任贤齐的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "任贤齐"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "陈东升的专辑"            , Genre = genres.Single(g => g.GenreName =="流行"  ), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==    "陈东升"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
                new Album {GroundingTime=DateTime.Now, AlbumNum=10 ,AlbumStatus=true, AlbumName = "光良的专辑"              , Genre = genres.Single(g => g.GenreName =="流行"), Price = 9.99M, Artist = artists.Single(a => a.ArtistName ==     "光良"                    ), AlbumArtUrl = "/images/placeholder.jpg" },
            }.ForEach(a => context.Albums.Add(a));
        }
    }
}